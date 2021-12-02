using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{

    public Animator anim;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isAiming;

    public GameObject weapon;
    /// <weapon ready/ not ready>
    public Transform WReady;
    public Transform WNotReady;
    /// </summary>
    


    // Start is called before the first frame update
    void Start()
    {
        
        WNotReady.transform.position = weapon.transform.position;
        WNotReady.transform.rotation = weapon.transform.rotation;
        //Vector3(-0.00185999996, 0.00307999994, 0.00307000009);//pos  Vector3(-0.00243000011,0.00319999992,0.00255999994)
        //Quaternion(0, -0.452434748, 0, 0.891797543);//rotation   Quaternion(-0.218622565,-0.426985323,0.193708897,0.855783105)
        isWalking = false;
        isRunning = false;
        isIdle = true;
        isAiming = false;

        anim = GetComponent<Animator>();

        anim.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {

        
        //if (isWalking)
        //{
        //    anim.Play("walking");
        //    //isRunning = false;
        //    //isIdle = false;
        //}

        //if(isRunning)
        //{
        //    anim.Play("Rifle Run");
        //    isWalking = false;
        //    isIdle = false;
        //}
        //if (isIdle)
        //{
        //    anim.Play("idle");
        //    isWalking = false;
        //    isRunning = false;

        //}
        //if(isAiming)
        //{
        //    weapon.transform.localPosition = new Vector3(-0.00243000011f,0.00319999992f,0.00255999994f);//pos
        //    weapon.transform.localRotation = new Quaternion(-0.218622565f, -0.426985323f, 0.193708897f, 0.855783105f);//rotation
        //    anim.Play("Firing Rifle");
        //    isWalking = false;
        //    isRunning = false;
        //    isIdle = false;
        //}
        //else
        //{   anim.StopPlayback();
        //    weapon.transform.localPosition = new Vector3(0.000230000005f, -0.00013f, 0.00179000001f);
        //    weapon.transform.localRotation = new Quaternion(0.372742593f, -0.481262475f, 0.236914799f, 0.757179439f);

        //    //return;
        //}
    }
}
