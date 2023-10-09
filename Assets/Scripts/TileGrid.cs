using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TileGrid
{

    private int width;
    private int height;
    private int[,] gridArray;

    public TileGrid(int width, int height, Tile defaultTile)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                TileWorld.SpawnTileWorld(new Vector3(x, y), defaultTile);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y);
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x);
        y = Mathf.FloorToInt(worldPosition.y);
    }

    public void SetTile(int x, int y, Tile tile)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = tile.tileID;
        }
    }

    public void SetTile(Vector3 worldPosition, Tile tile)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetTile(x, y, tile);
    }

    public void UpdateGrid()
    {

    }
}
