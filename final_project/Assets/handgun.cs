using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class handgun : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentHp;
    public float exp;
    public GameObject particleEffect;
    public GameObject player;
    public GameObject txtEffect;
    private GameObject parent;

    bool expSent;
    void Start()
    {
        
        expSent = true;
        exp = 50;
        currentHp = 10;
        particleEffect = Instantiate(particleEffect, transform);
        particleEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHp <=0)
        {
           if(expSent)
            {
                player.SendMessage("getExp",exp);
                expSent = false;
            }
            explode();
            //gameObject.GetComponent<Renderer>().material.color = new Color(168, 246,36);
        }
    }


    public void takeDamage(int dmg)
    {
        currentHp = currentHp - dmg;
        int dmgTaken = dmg;


        //GameObject nuObj = Instantiate(txtEffect, parent.transform);
        Debug.Log("took "+ dmg + " damage");
        //nuObj.transform. = gameObject.transform;
        //nuObj.SendMessage("dmgTxt",dmgTaken);
        //nuObj.GetComponent<TextMeshProUGUI>().text = dmgTaken.ToString();
    }

    public void explode()
    {
        float x = gameObject.transform.localRotation.x;
        float y = gameObject.transform.localRotation.y;
        float z = gameObject.transform.localRotation.z;
        gameObject.transform.localRotation = Quaternion.Euler(x,y,90f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,0, gameObject.transform.position.z);        
        particleEffect.SetActive(true);
        particleEffect.transform.position = gameObject.transform.position;
        StartCoroutine("removeFromGame");
        //Destroy(particleEffect, 1f);
        
    }


    IEnumerator removeFromGame()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }
}
