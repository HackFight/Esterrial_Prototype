using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Inventory
{

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void PrintInventory()
    {
        foreach (Item item in itemList) 
        {
            Debug.Log(item.itemScriptableObject.itemName + ", " + item.amount);
        }
    }
}
