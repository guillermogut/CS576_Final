using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmMenu : MonoBehaviour
{
    public GameObject actionMenu;
    public GameObject player;
    public GameObject playerStatus;
    public GameObject aimingSphere;
    public GameObject aimingCylinder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void confirm()
    {
        aimingSphere.SetActive(false);
        gameObject.SetActive(false);
        actionMenu.SetActive(false);
        player.GetComponent<player>().speed = 2;
        playerStatus.GetComponent<playerStatus>().currentAt = 0;
        player.GetComponent<player>().isActing = false;
        player.GetComponent<player>().isAiming = false;
        aimingCylinder.SetActive(false);
    }

    public void cancel()
    {
        gameObject.SetActive(false);
        player.GetComponent<player>().isConfirming = false;
        actionMenu.GetComponent<actionMenu>().setButtonInteract(true);

    }
}