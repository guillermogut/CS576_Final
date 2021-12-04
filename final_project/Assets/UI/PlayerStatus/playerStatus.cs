using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    ///  hook up the initial values for the resource bars from player script
    /// </summary>
    public float hp;
    public float currentHp;

    public float mp;
    public float currentMp;

    public float at;
    public float currentAt;

    public float mpSpeed;
    public float atSpeed;
    public float hpSpeed;

    public GameObject hpBar;
    public GameObject atBar;
    public GameObject mpBar;

    public GameObject AtColor;

    public GameObject ATFULL;

    private bool textSize;//use maybe

    public Text readyText;

    void Start()
    {
        textSize = true;
        hp = 100;
        currentHp = 100;

        mp = 100;
        currentMp = 0;

        at = 100;
        currentAt = 0;

        mpSpeed = 3f;
        atSpeed = 62f;
        hpSpeed = 0f;


    }

    // Update is called once per frame
    void Update()
    {

        //code for making AT bar message pulse
        if (currentAt == 100)
        {
            ATFULL.SetActive(true);
            //Debug.Log("Active");
            if (textSize)// text small
            {
                ATFULL.GetComponent<TextMeshProUGUI>().fontSize += .02f;// increase the font size
                if (ATFULL.GetComponent<TextMeshProUGUI>().fontSize > 18f)
                {
                    textSize = false;
                }
            }
            else
            {
                ATFULL.GetComponent<TextMeshProUGUI>().fontSize -= .02f;
                if (ATFULL.GetComponent<TextMeshProUGUI>().fontSize < 14f)
                {
                    textSize = true;
                }
            }

        }
        else
        {
            AtColor.GetComponent<Image>().color = Color.green;
            ATFULL.SetActive(false);
        }




        // code for hp mp and at bar movement
        currentHp += (hpSpeed * Time.deltaTime);

        if(currentHp > 100)
        {
            currentHp = 100;
        }
        hpBar.GetComponent<Slider>().value = currentHp/100;




        currentMp += (mpSpeed * Time.deltaTime);

        if (currentMp > 100)
        {
            currentMp = 100;
        }
        mpBar.GetComponent<Slider>().value = currentMp / 100;



        currentAt += atSpeed * Time.deltaTime;

        if(currentAt > 100)
        {
            currentAt = 100;
        }
        atBar.GetComponent<Slider>().value = currentAt / 100;

        if(currentAt == 100)
        {
            StartCoroutine("pulseColor", .25f);
            
            
        }
    }


    IEnumerator pulseColor(float seconds)
    {

        yield return new WaitForSeconds(seconds);

        if(AtColor.GetComponent<Image>().color == Color.green)
        {
            AtColor.GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            AtColor.GetComponent<Image>().color = Color.green;
        }


    }


}
