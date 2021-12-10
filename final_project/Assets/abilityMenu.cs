using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mpBar;
    public GameObject player;
    public GameObject anim;
    public GameObject playerStatus;

    private float prevSpeed;
    public float prevHealth;

    
    public void protectButton()
    {
        prevHealth = player.GetComponent<player>().health;

        playerStatus.GetComponent<playerStatus>().currentHp += 200;
        playerStatus.GetComponent<playerStatus>().hp += 200;

        player.GetComponent<player>().protect();
        gameObject.SetActive(false);
        player.GetComponent<animController>().abilityNum = 2;
        player.GetComponent<Animator>().SetBool("isHealing", true);//isHealing sets bool for all abilities
        mpBar.GetComponent<Slider>().value =0f;
    }

    public void hasteButton()
    {
        player.GetComponent<player>().prevSpeed = player.GetComponent<player>().currentSpeed;
        player.GetComponent<player>().currentSpeed = 5f;

        player.GetComponent<player>().haste();

        gameObject.SetActive(false);
        player.GetComponent<animController>().abilityNum = 1;
        player.GetComponent<Animator>().SetBool("isHealing", true);//isHealing sets bool for all abilities
        mpBar.GetComponent<Slider>().value =0f;
    }

    public void healButton()
    {
        if(GameObject.Find("HealthBar").GetComponent<Slider>().value + player.GetComponent<player>().health / 3 >1f)
        {
            GameObject.Find("HealthBar").GetComponent<Slider>().value = 1f;
        }
        else
        {
            GameObject.Find("HealthBar").GetComponent<Slider>().value += player.GetComponent<player>().health / 3;
        }
        
        gameObject.SetActive(false);
        player.GetComponent<animController>().abilityNum = 0;
        player.GetComponent<Animator>().SetBool("isHealing", true);//isHealing sets bool for all abilities
        mpBar.GetComponent<Slider>().value =0f;
        
    }
    
    public void exitAbility()
    {
        gameObject.SetActive(false);
    }
}
