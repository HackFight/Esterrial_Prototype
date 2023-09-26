using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    public int maxSlots;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.itemScriptableObject.isStackable)
        {
            bool itemAlreadyInInventory = false;


            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemScriptableObject.itemType == item.itemScriptableObject.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) 
            {
                itemList.Add(item);
            }
        }
        else
        { 
            itemList.Add(item);
        }

        if (itemList.Count > maxSlots) Debug.LogError("There is more slots used than the max slots count!");

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void PrintInventory()
    {
        foreach (Item item in itemList) 
        {
            Debug.Log(item.itemScriptableObject.itemName + ", " + item.amount);
        }
    }

    public List<Item> GetItemList() 
    {
        return itemList;
    }
}
