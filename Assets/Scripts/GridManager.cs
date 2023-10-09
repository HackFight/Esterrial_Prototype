using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 5, height = 5;
    public TileScriptableObject tileScriptableObject;

    private void Start()
    {
        TileGrid grid = new TileGrid(width, height, new Tile { tileScriptableObject = this.tileScriptableObject});
    }
}
