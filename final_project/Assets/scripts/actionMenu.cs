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
    }

    private void Update()
    {
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
        confirmSound.GetComponent<AudioSource>().Play();
        //player.GetComponent<player>().isConfirming = true;
        player.GetComponent<player>().isAiming = true;
        aimingSphere.SetActive(true);
        //confirmMenu.SetActive(true);
    }
    public void cancelButton()
    {
        cancelSound.GetComponent<AudioSource>().Play();



        if(player.GetComponent<player>().isActing&& aimingSphere.activeSelf)
        {
            Debug.Log("first");
            aimingSphere.SetActive(false);
            player.GetComponent<player>().target = null;
            aimingCylinder.SetActive(false);
            player.GetComponent<player>().isAiming = false;
        }
        else if(player.GetComponent<player>().isActing && !aimingSphere.activeSelf)
        {
            Debug.Log("second");
            player.GetComponent<player>().isActing = false;
            //aimingSphere.SetActive(false);
            aimingCylinder.SetActive(false);
            gameObject.SetActive(false);
            player.GetComponent<player>().speed = player.GetComponent<player>().currentSpeed;
            player.GetComponent<player>().isAiming = false;


        }
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

    
}
