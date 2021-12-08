using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class lvlUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject HealthBar;
    public Button healthButton;
    public Button attackButton;
    public Button speedButton;
    public Button attackSpeedButton;
    public GameObject statusPointsText;
    public GameObject actionMenu;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        player.GetComponent<player>().isLeveling = true;
    }
    // Update is called once per frame
    void Update()
    {
        statusPointsText.GetComponent<TextMeshProUGUI>().text = "Points Available: " + player.GetComponent<player>().statusPoints;

        if (player.GetComponent<player>().statusPoints == 0)
        {
            healthButton.interactable = false;
            attackButton.interactable = false;
            speedButton.interactable = false;
            attackSpeedButton.interactable = false;
        }
        else
        {
            healthButton.interactable = true;
            attackButton.interactable = true;
            speedButton.interactable = true;
            attackSpeedButton.interactable = true;
        }
    }


    public void increaseHealth()
    {
        if (player.GetComponent<player>().statusPoints > 0)
        {
            player.GetComponent<player>().statusPoints--;
        }
        
        player.GetComponent<player>().health += (int)(player.GetComponent<player>().health * .5);
    }

    public void increaseAttack()
    {
        if (player.GetComponent<player>().statusPoints > 0)
        {
            player.GetComponent<player>().statusPoints--;
        }
        
        player.GetComponent<player>().attack += 10;
    }

    public void increaseSpeed()
    {
        if (player.GetComponent<player>().statusPoints > 0)
        {
            player.GetComponent<player>().statusPoints--;
        }
        
        player.GetComponent<player>().speed += .2f;
    }
    public void increaseAttackSpeed()
    {
        if(player.GetComponent<player>().statusPoints>0)
        {
            player.GetComponent<player>().statusPoints--;
        }
        
        player.GetComponent<player>().attackSpeed += .2f;
    }

    public void exitLevelUp()
    {   
        
        player.GetComponent<player>().enabled = true;
        Debug.Log("player script " + player.GetComponent<player>().enabled);
        
        gameObject.SetActive(false);
        player.GetComponent<player>().speed = 2;
        actionMenu.GetComponent<actionMenu>().setButtonInteract(true);
    }
}
