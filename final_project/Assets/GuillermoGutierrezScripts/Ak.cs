using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ready;
    private Quaternion notReadyRot;
    private Quaternion ReadyRot;
    private Quaternion currentRot;


    private Vector3 readyVect;
    private Vector3 notReadyVect;
    // Update is called once per frame

    
    private void Start()
    {
        ready = true;
        notReadyRot = new Quaternion(0.222544044f, -0.60842216f, 0.187167525f, 0.738420665f);
        ReadyRot = new Quaternion(0, 0, 0, 1);

        notReadyVect = new Vector3(-0.0399999991f, 1.00699997f, 0.136000007f);
        readyVect = new Vector3(0.0140000004f, 1.15799999f, 0.331999987f);


    }
    void Update()
    {
        if(ready)
        {
            transform.rotation = Quaternion.Lerp(notReadyRot, ReadyRot, Time.time * 1f);
            transform.position = Vector3.Lerp(notReadyVect, readyVect, Time.time * 1f);
        }
    }
}
