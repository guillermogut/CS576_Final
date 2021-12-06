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

    public GameObject itemWindow;
    // Start is called before the first frame update
    void Start()
    {
        itemList = player.GetComponent<player>().itemList;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void populateInventory()
    {
        //get item list
        //get item slots
        //for every item in item list
        if (itemList.Count == 0) return;

        for(int i = 0; i < itemList.Count; i++)
        {
            if (!itemSlotHolder.transform.GetChild(i).GetComponent<itemSlot>().itemInSlot) continue;

            itemSlotHolder.transform.GetChild(i).GetComponent<itemSlot>().item = itemList[i];
            //itemSlotHolder.transform.GetChild(i).GetComponent<Image>().sprite = itemSlotHolder.transform.GetChild(i).GetComponent<itemSlot>().item.
        }
        //put in an available slot in item slots

    }

    public void removeItem()//put item arguement here
    {

    }


    public void exitItemList()
    {
        itemWindow.SetActive(false);
    }
}
