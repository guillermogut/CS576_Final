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
    public Animator animator;
    
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

        
        if (transform.rotation.y != 0 || transform.rotation.x != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }


        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;
        pos = new Vector3(x, 0f, z);

        if (isMoving)
        {

            animator.SetBool("isRunning", true);
            animator.SetBool("idle", false);
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
            Debug.Log("click");
            if(Vector3.Distance(pos, destination) < .05f)
            {
               
                animator.SetBool("isRunning", false);
                animator.SetBool("idle", true);


                //GetComponent<animController>().isIdle = true;
                //GetComponent<animController>().isRunning = false;
                //GetComponent<animController>().isWalking = false;
                speed = 0;
                isMoving = false;
            }
        }
        
        if(isActing)
        {
            speed = 0;
            animator.SetBool("idle", true);
            
            transform.rotation = transform.rotation;
            isMoving = false;

            Debug.Log("acting");
            if(isAiming)
            {
                
                Debug.Log("aiming");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("after aiming");
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
                   
                    turnPlayer(hit.point);
                    //GetComponent<animController>().isRunning = true;
                    speed = 2;
                    isMoving = true;


                }


            }

        }

        if (Input.GetKeyDown(KeyCode.Space) && atBar.GetComponent<Slider>().value ==1)
        {
            speed = 0;
            actionMenu.SetActive(true);


            //playerStatus.GetComponent<playerStatus>().currentAt = 0;
        }
       
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
