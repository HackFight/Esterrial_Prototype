using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tile
{

    public TileScriptableObject tileScriptableObject;

    public enum TileType
    {
        None,
        Ground,
        Mud,
        Tree,
    }

    public enum TileLayer
    {
        Ground,
        Middle,
        Top,
    }

    public Sprite GetSprite()
    {
        return tileScriptableObject.tileSprite;
    }
}
