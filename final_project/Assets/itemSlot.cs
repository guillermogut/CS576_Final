using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool itemInSlot;
    public GameObject item;

    private void Start()
    {
        itemInSlot = false;
    }
}
