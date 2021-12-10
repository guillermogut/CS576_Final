using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnight : MonoBehaviour
{
    private Animator animController;
    private CharacterController charController;
    private Vector3 direction;
    private float speed;
    private float lastBiteTime;

    const int STATE_IDLE = 0;
    const int STATE_CRAWLING = 1;
    const int STATE_SCURRYING = 2;
    const int STATE_BITING = 3;
    
    const float BITE_FREQ = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();

        gameObject.tag = "Enemy";

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentState();

        bool calcDirection = true;
        var state = animController.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Idle_Battle")) {
            // Do nothing
            speed = 0.0f;
            calcDirection = false;
        } else if (state.IsName("WalkForwardBattle")) {
            speed = 0.5f;
        } else if (state.IsName("RunForwardBattle")) {
            speed = 2.0f;
        } else if (state.IsName("Attack01")) {
            speed = 0.0f;

            float timeSinceLastBite = Time.time - lastBiteTime;
            if (timeSinceLastBite > BITE_FREQ) {
                GetPlayer().GetAttacked();
                lastBiteTime = Time.time;
            }
        }

        if (calcDirection) {
            direction = CalcDirection();
        }

        Vector3 newPosition = transform.position + (Time.deltaTime * speed * direction);
        bool nans = float.IsNaN(direction.x) || float.IsNaN(direction.y) || float.IsNaN(direction.z); // weird bug
        /*
        if (nans) {
            Debug.Log("old position: " + transform.position);
            Debug.Log(direction);
            Debug.Log(GetPlayer().speed);
            Debug.Log(GetPlayer().transform.forward);
            Debug.Log("new position: " + newPosition);
        }
        */
        if (!nans) {
            transform.position = newPosition;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    player GetPlayer() {
        return GameObject.Find("PlayerChar 3").GetComponent<player>();
    }

    void UpdateCurrentState() {
        // We should be in states:
        // Idle - when the rat is >C away from the player
        // Crawling - when the rat is between C and B away
        // Scurrying - when the rat is between B and A away
        // Biting - when it's <A feet of the player

        const float A = 2.0f, B = 10.0f, C = 20.0f;
        
        Vector3 playerPosition = GetPlayer().transform.position;
        Vector3 ratPosition = transform.position;
        float dist = (playerPosition - ratPosition).magnitude;
        //Debug.Log(dist);

        if (dist > C) {
            animController.SetInteger("state", STATE_IDLE);
        } else if (dist > B && dist <= C) {
            animController.SetInteger("state", STATE_CRAWLING);
        } else if (dist > A && dist <= B) {
            animController.SetInteger("state", STATE_SCURRYING);
        } else {
            animController.SetInteger("state", STATE_BITING);
        }
    }

    Vector3 CalcDirection() {
        var player = GetPlayer();
        Vector3 playerPosition = player.transform.position;
        Vector3 ratPosition = transform.position;
        if (!player.isMoving) {
            return Vector3.Normalize(playerPosition - ratPosition);
        }

        Vector3 playerVelocity = player.speed * player.transform.forward;
        float ratSpeed = speed;

         return DeflectionShooting(targetPosition: playerPosition, ourPosition: ratPosition, targetVelocity: playerVelocity, ourSpeed: ratSpeed);
    }

    // https://www.gamedev.net/tutorials/programming/math-and-physics/leading-the-target-r4223/
    // Returns: the direction the rat should be moving in
    Vector3 DeflectionShooting(Vector3 targetPosition, Vector3 ourPosition, Vector3 targetVelocity, float ourSpeed) {
        float t = 0.0f; // projected time of collision
        const int MAX_ITER = 100;
        const float EPSILON = 1e-4f;
        for (int i = 0; i < MAX_ITER; i++) {
            float oldT = t;
            Vector3 projectedTargetPosition = targetPosition + t * targetVelocity;
            t = (projectedTargetPosition - ourPosition).magnitude / ourSpeed;
            if (t - oldT < EPSILON) break;
        }
        Vector3 finalTargetPosition = targetPosition + t * targetVelocity;
        return Vector3.Normalize(finalTargetPosition - ourPosition);
    }
}
