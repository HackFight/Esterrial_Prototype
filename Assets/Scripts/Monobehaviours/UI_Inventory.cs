using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    public int slotsWidth;
    public float itemSlotCellSize = 0.5f;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0, y = 0;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image itemLogo = itemSlotRectTransform.Find("ItemLogo").GetComponent<Image>();
            itemLogo.sprite = item.itemScriptableObject.itemSprite;

            TextMeshProUGUI amountText = itemSlotRectTransform.Find("AmountText").GetComponent<TextMeshProUGUI>();

            if (item.amount > 1)
            {
                amountText.SetText(item.amount.ToString());
            }
            else
            {
                amountText.SetText("");
            }

            x++;
            if (x >= slotsWidth)
            {
                x = 0;
                y--;
            }
        }
    }
}
