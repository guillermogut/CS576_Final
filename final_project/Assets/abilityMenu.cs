using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mpBar;
    public GameObject player;


    public void protectButton()
    {
        player.GetComponent<Animator>().SetBool("isProtecting", true);
        mpBar.GetComponent<Slider>().value -= .75f;
    }

    public void hasteButton()
    {
        player.GetComponent<Animator>().SetBool("isHasting", true);//lol wtf
        mpBar.GetComponent<Slider>().value -= .75f;
    }

    public void healButton()
    {
        player.GetComponent<Animator>().SetBool("isHealing", true);
        mpBar.GetComponent<Slider>().value -= .75f;
    }

    public void exitAbility()
    {
        gameObject.SetActive(false);
    }
}
