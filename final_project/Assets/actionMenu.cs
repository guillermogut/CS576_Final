using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject aimingSphere;
    public GameObject confirmMenu;
    // Start is called before the first frame update
    private void OnEnable()
    {
        player.GetComponent<player>().isActing = true;
        

    }




    public void attackButton()
    {
        player.GetComponent<player>().isConfirming = true;
        aimingSphere.SetActive(true);
        confirmMenu.SetActive(true);
    }
    public void cancelButton()
    {
        
        if(player.GetComponent<player>().isActing = true && aimingSphere.activeSelf)
        {
            aimingSphere.SetActive(false);
        }
        else if(player.GetComponent<player>().isActing = true && !aimingSphere.activeSelf)
        {
            player.GetComponent<player>().isActing = false;
            aimingSphere.SetActive(false);
            gameObject.SetActive(false);
            player.GetComponent<player>().speed = 2;
        }
    }
    public void itemButton()
    {

    }
}
