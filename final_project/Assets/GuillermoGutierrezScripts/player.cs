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
    public float mana;
    public int attack;
    public float attackSpeed;
    public float speed;//speed
    public float currentSpeed;
    public float prevSpeed;
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
    public bool pepsi;//pepsi = isded
    //public bool isHit;

    public GameObject aimingSphere;
    public GameObject target;
    public GameObject targetCylinder;

    public GameObject actionMenu;

    public GameObject playerStatus;
    public GameObject atBar;
    public GameObject confirmMenu;
    public GameObject lvlMenu;
    public GameObject placeHolderItem;
    public GameObject abilityMenu;

    public bool gotItemTest = false;
    public List<GameObject> itemList;

    public bool invulFrames = false;

    public bool protectEffect = false;

    public bool doingAThing = false;
    //effects
    public GameObject airTxt;
    void Start()
    {
        target = null;
        Time.timeScale = 1f;
        isMoving = false;
        isActing = false;
        isAiming = false;
        isConfirming = false;
        isFiring = false;
        isLeveling = false;
        //isHit = false;
        lookVector = new Vector3(0f, 0f, 1f);

        abilityMenu = GameObject.Find("abilityMenu");
        if (playerProgression._gameStart)
        {
            
            playerObj.transform.position = new Vector3(0f, 0f, 0f);
            pos = playerObj.transform.position;
            health = 100;
            mana = 0;
            attack = 50;
            attackSpeed = 1;
            currentSpeed = 2f; 
            //speed = 1f;
            level = 0;
            statusPoints = 0;
            
        }
        else
        {
            loadPlayerInfo();
            
        }

        expForNext = getExperienceForNextLevel(level + 1);
    }

    private void OnEnable()
    {
        lvlMenu.GetComponent<lvlUp>().exitLevelUp();
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision ");
        if (collision.collider.tag == "Untagged")
        {
            isMoving = false;
            speed = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gotItemTest)
        {
            //for testing item system
            //getItem();
            gotItemTest = false;
        }
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
            if (Vector3.Distance(pos, destination) < .1f)
            {

                speed = 0;
                isMoving = false;
            }
        }
        if (!isMoving)
        {

        }
        if (isActing)
        {
            speed = 0;


            transform.rotation = transform.rotation;
            isMoving = false;

            //Debug.Log("acting");
            if (isAiming)
            {

                //Debug.Log("aiming");
                if (Input.GetMouseButtonDown(0) && !doingAThing)
                {
                    //Debug.Log("after aiming");
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("enemy name: " + hit.collider.name);
                        if (hit.collider.tag == "Enemy" && hit.collider.bounds.Intersects(aimingSphere.GetComponent<Collider>().bounds))
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
        if (Input.GetMouseButtonDown(0) && !isActing && !doingAThing)
        {

            GetComponent<animController>().isAiming = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("currenct map name: " + hit.collider.name);



                turnPlayer(hit.point);
                speed = currentSpeed;
                isMoving = true;

            }

        }

        if (Input.GetKeyDown(KeyCode.Space) && atBar.GetComponent<Slider>().value == 1 && !doingAThing)
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

        return lvl * 100;
        //return Mathf.Log(lvl2)* Mathf.Log(lvl2) + 2*Mathf.Log(lvl2)* 50;
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

    public void getItem(GameObject theThing)
    {
        Debug.Log("got item");

        //GameObject test = Instantiate(placeHolderItem, transform);
        //itemList.Add(test);
        //for (int i = 0; i < 15; i++)
        //{
        //    GameObject test = Instantiate(placeHolderItem, transform);
        //    itemList.Add(test);
        //}
        itemList.Add(theThing);
        Debug.Log("item list length: "+ itemList.Count);
    }

   
    public void GetAttacked() {
        // Triggered when the player is attacked by an enemy
        
        //StartCoroutine("setInvulFrames");
        if (invulFrames) return;

        if(!invulFrames)
        {
            StartCoroutine("setInvulFrames");
            //isHit = true;
            if (protectEffect)
            {
                playerStatus.GetComponent<playerStatus>().currentHp -= 30 / 2;

            }
            else
            {
                playerStatus.GetComponent<playerStatus>().currentHp -= 30;
            }
        }
        
    }

    public void haste()
    {
        StartCoroutine("hasteCountdown");
    }

    public void protect()
    {
        StartCoroutine("protectCountdown");
    }

    IEnumerator hasteCountdown()
    {

        yield return new WaitForSeconds(15F);
        
        GetComponent<player>().currentSpeed = prevSpeed;

    }

    IEnumerator setInvulFrames()
    {
        invulFrames = true;
        yield return new WaitForSeconds(2F);

        invulFrames = false;
    }
    IEnumerator protectCountdown()
    {
        yield return new WaitForSeconds(20F);

        protectEffect = false;
    }

    private void loadPlayerInfo()
    {
        playerProgression._itemList = itemList;
        playerProgression._health = health;
        playerProgression._mana = mana;
        playerProgression._attack = attack;
        playerProgression._attackSpeed = attackSpeed;
        playerProgression._level = level;
        playerProgression._exp = exp;
        playerProgression._statusPoints = statusPoints;
        

    }
}
