using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_Inventory inventoryUI;

    [SerializeField] private ItemScriptableObject testItemScriptableObject;

    [SerializeField] private StartingItem[] startingItemArray;

    [System.Serializable]
    private struct StartingItem
    {
        public ItemScriptableObject itemScriptableObject;
        public int amount;
    }

    private void Awake()
    {
        inventory = new Inventory();
        inventory.maxSlots = 1;
        LoadStartingInventory();
    }

    private void LoadStartingInventory()
    {
        foreach (StartingItem startingItem in startingItemArray)
        {
            Item item = new Item();
            item.itemScriptableObject = startingItem.itemScriptableObject;
            item.amount = startingItem.amount;
            inventory.AddItem(item);
        }

        inventoryUI.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}