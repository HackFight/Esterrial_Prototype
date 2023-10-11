using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    private Transform player;
    private Tilemap tilemap;

    [SerializeField] private Tile groudTile;
    [SerializeField] private int width, height;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector2 originPosition;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        tilemap = new Tilemap(width, height, cellSize, new Vector3(originPosition.x, originPosition.y, 0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            tilemap.SetTile(player.position, groudTile);
        }
    }
}
