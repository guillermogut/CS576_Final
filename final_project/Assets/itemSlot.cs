using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool itemInSlot;
    public GameObject item;
    public Texture2D blank;
    public GameObject itemMenu;
    

    private void Start()
    {
        if(item == null)
        {
            itemInSlot = false;
        }
        else
        {
            itemInSlot = true;
        }
    }


    public void placeItemInSlot(GameObject thing)
    {
        item = thing;
        itemInSlot = true;
    }

    public void useItem()
    {   
        if (!itemInSlot) return;
        itemInSlot = false;
        //play item animation here
        Debug.Log("item selected in slot-----------------");

        itemMenu.GetComponent<itemMenu>().selectItem(gameObject);

        //item.GetComponent<placeHolderItem>().itemAbility();
        item = null;
        gameObject.GetComponent<Image>().sprite = Sprite.Create(blank,new Rect(0.0f, 0.0f, blank.width, blank.height),new Vector2(0.5f, 0.5f),100.0f);
    }
    public void selectThisItem()
    {
        
        itemMenu.GetComponent<itemMenu>().selectItem(GetComponent<itemSlot>().item);
        
        itemMenu.GetComponent<itemMenu>().itemSelected = true;
    }
}
