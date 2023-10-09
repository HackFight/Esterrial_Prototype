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

    public int tileID;

    public void InitTile()
    {
        tileID = tileScriptableObject.ID;
    }

    public Sprite GetSprite()
    {
        return tileScriptableObject.tileSprite;
    }
}
