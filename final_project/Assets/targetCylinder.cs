using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCylinder : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            transform.position = player.GetComponent<player>().target.transform.position;
        }
    }
}
