using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

    public Material GetMaterial()
    {
        if (tileScriptableObject!= null)
        {
            return tileScriptableObject.tileMaterial;
        }
        else
        {
            Debug.LogError("Your tileScriptableObject is null!");
            return null;
        }
    }
}
