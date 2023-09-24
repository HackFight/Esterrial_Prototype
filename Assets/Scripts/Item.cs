using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
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
