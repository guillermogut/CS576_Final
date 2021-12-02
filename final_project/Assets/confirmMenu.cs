using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmMenu : MonoBehaviour
{
    public GameObject actionMenu;
    public GameObject player;
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
        gameObject.SetActive(false);
        actionMenu.SetActive(false);
    }

    public void cancel()
    {
        gameObject.SetActive(false);
        player.GetComponent<player>().isConfirming = false;
    }
}
