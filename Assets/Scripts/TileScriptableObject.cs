using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TileScriptableObject")]
public class TileScriptableObject : ScriptableObject
{
    public Tile.TileType tileType;
    public string tileName;
    public Sprite tileSprite;

    public Tile.TileLayer layer;
}
