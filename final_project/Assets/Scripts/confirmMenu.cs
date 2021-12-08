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
    public Animator anim;
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
        player.GetComponent<player>().speed = player.GetComponent<player>().currentSpeed;
        
        player.GetComponent<player>().isActing = false;
        player.GetComponent<player>().isAiming = false;
        player.GetComponent<player>().isFiring = true;
        aimingCylinder.SetActive(false);
    }

    public void cancel()
    {
        gameObject.SetActive(false);
        player.GetComponent<player>().isConfirming = false;
        actionMenu.GetComponent<actionMenu>().setButtonInteract(true);
        aimingCylinder.SetActive(false);

    }
}
