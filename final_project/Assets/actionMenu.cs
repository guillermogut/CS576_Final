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


    public void attackButton()
    {
        //player.GetComponent<player>().isConfirming = true;
        player.GetComponent<player>().isAiming = true;
        aimingSphere.SetActive(true);
        //confirmMenu.SetActive(true);
    }
    public void cancelButton()
    {
        
        if(player.GetComponent<player>().isActing = true && aimingSphere.activeSelf)
        {
            aimingSphere.SetActive(false);
            player.GetComponent<player>().target = null;
            aimingCylinder.SetActive(false);
            player.GetComponent<player>().isAiming = false;
        }
        else if(player.GetComponent<player>().isActing = true && !aimingSphere.activeSelf)
        {
            player.GetComponent<player>().isActing = false;
            aimingSphere.SetActive(false);
            aimingCylinder.SetActive(false);
            gameObject.SetActive(false);
            player.GetComponent<player>().speed = 2;
            player.GetComponent<player>().isAiming = false;



        }
    }
    public void itemButton()
    {

    }
}
