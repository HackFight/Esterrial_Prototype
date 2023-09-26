using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObject")]
public class ItemScriptableObject : ScriptableObject
{
    public Item.ItemType itemType;
    public string itemName;
    public Sprite itemSprite;

    public bool isStackable;
    /*public int maxStack
    {
        get { return _maxStack; }
        set { if (_maxStack < 1) maxStack = 1; else maxStack = _maxStack; }
    }

    [SerializeField] private int _maxStack;*/
}
