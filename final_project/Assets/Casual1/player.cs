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
    public int health;
    public int attack;
    public float attackSpeed;
    public float speed;//speed
    public float currentSpeed;
    public int level;
    public float exp;
    public float expForNext;
    public int statusPoints;
    
    private Vector3 lookVector;//WHERE SHE LOOKIN AT
    private GameObject lookArrow;
    public bool isMoving;
    public bool isActing;
    public bool isAiming;
    public bool isConfirming;
    public bool isFiring;
    public bool isLeveling;

    public GameObject target;
    public GameObject targetCylinder;

    public GameObject actionMenu;

    public GameObject playerStatus;
    public GameObject atBar;
    public GameObject confirmMenu;
    public GameObject lvlMenu;

    //effects
    public GameObject airTxt;
    void Start()
    {
        target = null;
        Time.timeScale = 1f;
  
        playerObj.transform.position = new Vector3(0f,0f,0f);
        pos = playerObj.transform.position;

        health = 100;
        attack = 50;
        attackSpeed = 1;
        isMoving = false;
        isActing = false;
        isAiming = false;
        isConfirming = false;
        isFiring = false;
        isLeveling = false;
        lookVector = new Vector3(0f,0f,1f);
        currentSpeed = 2f;
        //speed = 1f;
        level = 0;
        statusPoints = 0;
        expForNext = getExperienceForNextLevel(level + 1);

    }

    private void OnEnable()
    {
        lvlMenu.GetComponent<lvlUp>().exitLevelUp();
       
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("speed: " + speed);
        if (transform.rotation.y != 0 || transform.rotation.x != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }


        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;
        pos = new Vector3(x, 0f, z);

        if (isMoving)
        {

            this.transform.position += this.transform.forward * speed * Time.deltaTime;
            //Debug.Log("click");
            if(Vector3.Distance(pos, destination) < .05f)
            {

                speed = 0;
                isMoving = false;
            }
        }
        if(!isMoving)
        {

        }
        if(isActing)
        {
            speed = 0;

            
            transform.rotation = transform.rotation;
            isMoving = false;

            //Debug.Log("acting");
            if(isAiming)
            {
                
                //Debug.Log("aiming");
                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("after aiming");
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


    public float getExperienceForNextLevel(int lvl)
    {
        int lvl2 = lvl;

        if (lvl == 1) return 50f;
        return Mathf.Log(lvl2)* Mathf.Log(lvl2) + 2*Mathf.Log(lvl2)* 50;
    }

    public void getExp(float exp)
    {
        
        this.exp += exp;

        if(this.exp >= expForNext)
        {//Debug.Log("exp GOT");
            //show lvl up effect
            Instantiate(airTxt,transform);
            statusPoints++;
            level++;
            expForNext = getExperienceForNextLevel(level+1);
        }
    }


}
