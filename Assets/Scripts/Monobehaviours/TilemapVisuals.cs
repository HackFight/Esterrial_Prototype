using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapVisuals : MonoBehaviour 
{

    private Grid<Tilemap.TilemapObject> grid;
    private Mesh mesh;
    private MeshRenderer meshRenderer;
    private bool updateMesh;

    private void Awake() 
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetGrid(Grid<Tilemap.TilemapObject> grid) 
    {
        this.grid = grid;
        UpdateHeatMapVisual();

        grid.OnGridObjectChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, Grid<Tilemap.TilemapObject>.OnGridObjectChangedEventArgs e) 
    {
        updateMesh = true;
    }

    private void LateUpdate() 
    {
        if (updateMesh) {
            updateMesh = false;
            UpdateHeatMapVisual();
        }
    }

    private void UpdateHeatMapVisual() 
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++) {
            for (int y = 0; y < grid.GetHeight(); y++) {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

                Tilemap.TilemapObject gridObject = grid.GetGridObject(x, y);
                Material tilemapMaterial = gridObject.GetMaterial();
                meshRenderer.material = tilemapMaterial;
                Tile.TileType tileType = gridObject.GetTile().tileScriptableObject.tileType;
                Vector2 gridUV00, gridUV11;
                if (tileType == Tile.TileType.None)
                {
                    gridUV00 = Vector2.zero;
                    gridUV11 = Vector2.zero;
                    quadSize = Vector3.zero;
                }
                else
                {
                    gridUV00 = Vector2.one;
                    gridUV11 = Vector2.zero;
                }
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, gridUV00, gridUV11);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

}