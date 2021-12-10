using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemEffects : MonoBehaviour
{

    public playerStatus playerStatus;
    public string type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void applyEffect()
    {

        if (type == "hp")
        {
            float boost = playerStatus.hpSpeed * 1.25f;
            playerStatus.hpSpeed += boost;
            StartCoroutine(unapplyEffect(5, "hp", boost));
        } 
        else if (type == "mp")
        {
            float boost = playerStatus.mpSpeed * 1.25f;
            playerStatus.mpSpeed += boost;
            StartCoroutine(unapplyEffect(5, "mp", boost));
        } 
        else if (type == "at")
        {
            float boost = playerStatus.atSpeed * 1.25f;
            playerStatus.atSpeed += boost;
            StartCoroutine(unapplyEffect(5, "at", boost));
        }
    }

    IEnumerator unapplyEffect(float time, string type, float boost)
    {
        yield return new WaitForSeconds(time);

        // boom

        if (type == "hp")
        {
            playerStatus.hpSpeed -= boost;
        }
        else if (type == "mp")
        {
            playerStatus.mpSpeed -= boost;
        }
        else if (type == "at")
        {
            playerStatus.atSpeed -= boost;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hello world");

        if (collision.gameObject.name == "PlayerChar 3")
        {
            playerStatus = collision.gameObject.GetComponent<playerStatus>();
            applyEffect();
            Destroy(gameObject);
        }
    }

}
