using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileWorld : MonoBehaviour
{
    public static TileWorld SpawnTileWorld(UnityEngine.Vector3 position, Tile tile)
    {
        Transform transform = Instantiate(Assets.Instance.tileWorldPrefab, position, UnityEngine.Quaternion.identity);

        TileWorld tileWorld = transform.GetComponent<TileWorld>();
        tileWorld.SetTile(tile);

        return tileWorld;
    }

    private Tile tile;
    private SpriteRenderer spriteRenderer;

    private GameObject player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    public void SetTile(Tile tile)
    {
        this.tile = tile;
        spriteRenderer.sprite = tile.tileScriptableObject.tileSprite;
    }

    public Tile GetTile()
    {
        return tile;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
