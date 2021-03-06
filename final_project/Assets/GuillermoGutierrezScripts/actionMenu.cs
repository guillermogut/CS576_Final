using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject aimingSphere;
    public GameObject confirmMenu;
    public GameObject playerStatus;
    public GameObject aimingCylinder;
    public Button lvlButton;
    public GameObject levelMenu;
    public GameObject confirmSound;
    public GameObject cancelSound;
    public GameObject itemMenu;
    public GameObject mpBar;
    public GameObject abilityMenu;
    public GameObject abilities;
    public GameObject cancelButtonObj;

    // Start is called before the first frame update
    private void OnEnable()
    {
        player.GetComponent<player>().isActing = true;
        
        setButtonInteract(true);

    }

    public void setButtonInteract(bool x)
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (var button in buttons)
        {
            button.interactable = x;
        }
        abilities.GetComponent<Button>().interactable = x;
    }
    public void setButtonInteractButCancel(bool x)
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (var button in buttons)
        {
            button.interactable = x;
        }
        abilities.GetComponent<Button>().interactable = x;
        cancelButtonObj.GetComponent<Button>().interactable = true;
    }

    private void Update()
    {
        if(player.GetComponent<player>().isAiming || player.GetComponent<player>().isConfirming)
        {
            abilities.GetComponent<Button>().interactable = false;
        }
        if(player.GetComponent<player>().statusPoints>0)
        {
            lvlButton.interactable = true;
        }
        else
        {
            lvlButton.interactable = false;
        }
    }
    public void attackButton()
    {
        player.GetComponent<Rigidbody>().detectCollisions = false;
        confirmSound.GetComponent<AudioSource>().Play();
        //player.GetComponent<player>().isConfirming = true;
        player.GetComponent<player>().isAiming = true;
        aimingSphere.SetActive(true);
        setButtonInteractButCancel(false);

        //confirmMenu.SetActive(true);
    }
    public void cancelButton()
    {
        cancelSound.GetComponent<AudioSource>().Play();



        if(player.GetComponent<player>().isActing&& aimingSphere.activeSelf)
        {
            player.GetComponent<Rigidbody>().detectCollisions = true;
            
            aimingSphere.SetActive(false);
            player.GetComponent<player>().target = null;
            aimingCylinder.SetActive(false);
            player.GetComponent<player>().isAiming = false;
        }
        else if(player.GetComponent<player>().isActing && !aimingSphere.activeSelf)
        {
            
            player.GetComponent<Rigidbody>().detectCollisions = true;
            player.GetComponent<player>().isActing = false;
            //aimingSphere.SetActive(false);
            aimingCylinder.SetActive(false);
            gameObject.SetActive(false);
            player.GetComponent<player>().speed = player.GetComponent<player>().currentSpeed;
            player.GetComponent<player>().isAiming = false;


        }
        setButtonInteract(true);
    }
    public void itemButton()
    {
        itemMenu.SetActive(true);
    }

    public void levelUpButton()
    {
        confirmSound.GetComponent<AudioSource>().Play();
        //player.GetComponent<player>().isLeveling = true;
        player.GetComponent<player>().enabled = false;
        levelMenu.SetActive(true);
        setButtonInteract(false);
    }

    public void abilityButton()
    {
        abilityMenu.SetActive(true);
    }
    public void healButton()
    {
        player.GetComponent<Animator>().SetBool("isHealing",true);
        mpBar.GetComponent<Slider>().value = 0f;
    }
    public void protectButton()
    {
        player.GetComponent<Animator>().SetBool("isHealing", true);
        mpBar.GetComponent<Slider>().value = 0f;
    }
    public void hasteButton()
    {
        player.GetComponent<Animator>().SetBool("isHealing", true);
        mpBar.GetComponent<Slider>().value = 0f;
    }
}
