using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimingSphere : MonoBehaviour
{

    private float growSpeed;
    private float rotateSpeed;
    private float growAndrotateSpeed;
    public float scale;
    public GameObject player;
    // Start is called before the first frame update

    private void Start()
    {
        scale = 5;
        growAndrotateSpeed = 5f;
        rotateSpeed = 1f;
        growSpeed = 5f;
    }
    public void OnEnable()
    {
        gameObject.transform.position = player.transform.position;
        gameObject.transform.localScale = new Vector3(0, 0, 0);

    }

     public void Update()
    {
        
        if (transform.localScale.z < scale)
        {
            transform.localScale = transform.localScale + new Vector3(1f,1f,1f) * Time.deltaTime* growSpeed;
            //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + transform.rotation.y*growAndrotateSpeed* Time.deltaTime, transform.rotation.z));
            Vector3 rotationToAdd = new Vector3(0, 1, 0);
            transform.Rotate(rotationToAdd);
        }
        else
        {
            Vector3 rotationToAdd = new Vector3(0, .01f, 0);
            transform.Rotate(rotationToAdd);
            //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + transform.rotation.y * 1f * Time.deltaTime, transform.rotation.z));
        }
    }
}
