using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(UnityEngine.Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.itemWorldPrefab, position, UnityEngine.Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private GameObject player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("AmountText").GetComponent<TextMeshPro>();
        player = GameObject.FindWithTag("Player");
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.itemScriptableObject.itemSprite;

        if (item.amount > 1)
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }

        if (item.amount < 1)
        {
            item.amount = 1;
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
