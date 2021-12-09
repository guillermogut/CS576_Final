using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class itemMenu : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> itemList;
    public GameObject itemSlotHolder;
    private GameObject[] itemSlots;
    public GameObject selectedItem;
    public GameObject itemWindow;
    public bool itemSelected;
    // Start is called before the first frame update
    void Start()
    {
        itemList = player.GetComponent<player>().itemList;
        itemSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        populateInventory();
        

    }

    public void OnDisable()
    {
        for (int i = 0; i < player.GetComponent<player>().itemList.Count; i++)
        {
            itemSlotHolder.transform.GetChild(i).DetachChildren();
            itemSlotHolder.transform.GetChild(i).GetComponent<Button>().image.overrideSprite = itemSlotHolder.transform.GetChild(i).GetComponent<itemSlot>().blank;
     
        }
    }
    public void populateInventory()
    {Debug.Log("pop inventory, list length: "+ player.GetComponent<player>().itemList.Count);
 
        if (player.GetComponent<player>().itemList.Count == 0) return;

        for (int i = 0; i < player.GetComponent<player>().itemList.Count; i++)
        {

            player.GetComponent<player>().itemList[i].transform.SetParent(itemSlotHolder.transform.GetChild(i));

            if(itemSlotHolder.transform.GetChild(i).childCount == 0)
            {
                itemSlotHolder.transform.GetChild(i).GetComponent<Button>().image.overrideSprite = itemSlotHolder.transform.GetChild(i).GetComponent<itemSlot>().blank;
            }
            else
            {
                itemSlotHolder.transform.GetChild(i).GetComponent<Button>().image.overrideSprite = itemSlotHolder.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
            
      
        }
        

    }

    public void selectItem(GameObject selectedThing)
    {
        Debug.Log("SELECTED ITEM TO USE--------> " + selectedItem.transform.parent.name);
        Debug.Log("ITEM NOW SELECTED");
        
        selectedItem = selectedThing;
    }
    public void useItem()
    {
         Debug.Log("in useItem");
        
        if (itemSelected && selectedItem != null)
        {

            selectedItem.GetComponent<placeHolderItem>().itemAbility();

           
            Debug.Log(selectedItem.transform.parent.gameObject.GetComponent<Button>());

            selectedItem.transform.parent.gameObject.GetComponent<Button>().image.overrideSprite = selectedItem.transform.parent.gameObject.GetComponent<itemSlot>().blank;
            Debug.Log("before list count: " + player.GetComponent<player>().itemList.Count);
            player.GetComponent<player>().itemList.Remove(selectedItem);
            Debug.Log("after list count: " + player.GetComponent<player>().itemList.Count);
            Destroy(selectedItem);


            itemSelected = false;
        }
        else
        {
            Debug.Log("NO ITEM SELECTED");
        }
    }
    public void removeItem()//put item arguement here
    {
        
       
    }


    public void exitItemList()
    {
        itemWindow.SetActive(false);
    }

    
}
