using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{

    public enum ItemType
    {
        Silex,
        MagicCrystal,
        Apple,
        Bread,
    }

    public ItemScriptableObject itemScriptableObject;
    public int amount;
}
