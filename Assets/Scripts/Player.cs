using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    public ItemScriptableObject startingObject;

    private void Awake()
    {
        inventory = new Inventory();

        inventory.AddItem(new Item { itemScriptableObject = startingObject, amount = 1 });
        inventory.PrintInventory();
    }
}
