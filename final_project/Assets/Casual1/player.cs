using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObj;
    public GameObject currentMap;
    private Animator animator;
    
    public Vector3 pos;
    private Vector3 destination;
    public float speed;//speed
    
    private Vector3 lookVector;//WHERE SHE LOOKIN AT
    private GameObject lookArrow;
    public bool isMoving;
    public bool isActing;
    public bool isAiming;
    public bool isConfirming;

    public GameObject target;
    public GameObject targetCylinder;

    public GameObject actionMenu;

    public GameObject playerStatus;
    public GameObject atBar;
    public GameObject confirmMenu;
    void Start()
    {
        target = null;
        Time.timeScale = 1f;
  
        playerObj.transform.position = new Vector3(0f,0f,0f);
        pos = playerObj.transform.position;
       

        isMoving = false;
        isActing = false;
        isAiming = false;
        isConfirming = false;
        lookVector = new Vector3(0f,0f,1f);
        //speed = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.y != 0 || transform.rotation.x != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }


        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;
        pos = new Vector3(x, 0f, z);

        if (isMoving)
        {
            
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
            Debug.Log("click");
            if(Vector3.Distance(pos, destination) < .05f)
            {
               
                GetComponent<animController>().isIdle = true;
                GetComponent<animController>().isRunning = false;
                GetComponent<animController>().isWalking = false;
                isMoving = false;
            }
        }
        if(isActing)
        {
            speed = 0;
            transform.rotation = transform.rotation;
            isMoving = false;

            Debug.Log("acting");
            if(isAiming)
            {
                Debug.Log("aiming");
                if (Input.GetMouseButtonDown(0))
                {

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.name == "Handgun")
                        {
                            
                            turnPlayer(hit.point);
                            target = hit.collider.gameObject;
                            targetCylinder.SetActive(true);
                            targetCylinder.transform.position = target.transform.position;
                            confirmMenu.SetActive(true);

                            actionMenu.GetComponent<actionMenu>().setButtonInteract(false);
                            
                            
                        }


                    }
                }
            }
           
        }
        if(Input.GetMouseButtonDown(0) && !isActing)
        {

            GetComponent<animController>().isAiming = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == currentMap.name)
                {
                    //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    //sphere.transform.localScale = new Vector3(.2f, .2f, .2f);
                    //sphere.transform.position = hit.point;



                    //Vector3 dest = hit.point;
                    //dest.y = 0f;


                    //Destroy(sphere, 10f);

                    turnPlayer(hit.point);
                    GetComponent<animController>().isRunning = true;
                    isMoving = true;


                }


            }

            //if(isActing)
            //{

            //}
            //else
            //{
            //    GetComponent<animController>().isAiming = false;
            //    RaycastHit hit;
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    if (Physics.Raycast(ray, out hit))
            //    {
            //        if (hit.collider.name == currentMap.name)
            //        {
            //            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //            //sphere.transform.localScale = new Vector3(.2f, .2f, .2f);
            //            //sphere.transform.position = hit.point;



            //            //Vector3 dest = hit.point;
            //            //dest.y = 0f;


            //            //Destroy(sphere, 10f);

            //            turnPlayer(hit.point);
            //            GetComponent<animController>().isRunning = true;
            //            isMoving = true;


            //        }


            //    }
            //}


        }

        if (Input.GetKeyDown(KeyCode.Space) && atBar.GetComponent<Slider>().value ==1)
        {

            actionMenu.SetActive(true);


            //playerStatus.GetComponent<playerStatus>().currentAt = 0;
        }
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    GetComponent<RigBuilder>().enabled = false;
        //    isMoving = false;
        //    GetComponent<animController>().isWalking = false;
        //    GetComponent<animController>().isRunning = false;
        //    GetComponent<animController>().isIdle = false;
        //    GetComponent<animController>().isAiming = true;
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    GetComponent<RigBuilder>().enabled = true;
        //}
    }

    void turnPlayer(Vector3 dest)
    {

        destination = dest;
        transform.LookAt(dest);


    }

    void renderVect(Vector3 vToRend)
    {
        GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cyl.transform.localScale = new Vector3(.2f, .2f, 1f);
        cyl.transform.position = pos;
    }
}
