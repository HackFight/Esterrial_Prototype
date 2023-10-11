using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap
{

    private Grid<TilemapObject> grid;

    public Tilemap(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.grid = new Grid<TilemapObject>(width, height, cellSize, originPosition, (Grid<TilemapObject> g, int x, int y) => new TilemapObject(g, x, y, Assets.Instance.GetTileFromTileScriptableObject(Assets.Instance.emptyTileScriptableObject)));
    }

    public void SetTile(Vector3 worldPosition, Tile tile)
    {
        TilemapObject tilemapObject = grid.GetGridObject(worldPosition);

        if (tilemapObject != null)
        {
            tilemapObject.SetTile(tile);
        }
    }

    public class TilemapObject
    {
        private Grid<TilemapObject> grid;
        private int x;
        private int y;
        private Tile tilemapTile;

        public TilemapObject(Grid<TilemapObject> grid, int x, int y, Tile tilemapTile)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.tilemapTile = tilemapTile;
        }

        public void SetTile(Tile tilemapTile) 
        {
            this.tilemapTile = tilemapTile;
            grid.TriggerGridObjectChanged(x, y);
        }
    }
}
