using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool itemInSlot;
    public GameObject item;
    public Sprite blank;
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

    public void OnDisable()
    {
        GetComponent<Button>().image.overrideSprite = blank;
    }
    public void placeItemInSlot(GameObject thing)
    {
        Debug.Log("placing item in slot: " + thing.name);
        item = thing;
        itemInSlot = true;
    }

    public void selectThisItem()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("nothing to select");
            return;
        }
        //itemMenu.GetComponent<itemMenu>().selectItem(item);
        Debug.Log("in selectThisItem(), the item is " + item.name);
        itemMenu.GetComponent<itemMenu>().selectedItem = transform.GetChild(0).gameObject;
        
        itemMenu.GetComponent<itemMenu>().itemSelected = true;
    }
}
