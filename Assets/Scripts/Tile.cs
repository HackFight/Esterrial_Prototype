using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{

    public enum TileType
    {
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

    public TileScriptableObject tileScriptableObject;

    public Sprite GetSprite()
    {
        return tileScriptableObject.tileSprite;
    }
}
