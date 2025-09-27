using UnityEngine;
using System.Collections.Generic;

public class BackgroundTiler : MonoBehaviour
{
    [SerializeField] private Transform player;       // player or camera to follow
    [SerializeField] private GameObject tilePrefab;  // your background tile prefab
    [SerializeField] private int gridSize = 3;       // always odd (3 = 3x3 grid)

    private float tileWidth, tileHeight;
    private Dictionary<Vector2Int, GameObject> tiles = new Dictionary<Vector2Int, GameObject>();

    private Vector2Int currentTileIndex;

    void Start()
    {
        // Get size of the tile
        SpriteRenderer sr = tilePrefab.GetComponent<SpriteRenderer>();
        tileWidth = sr.bounds.size.x;
        tileHeight = sr.bounds.size.y;

        // Spawn grid of tiles
        int half = gridSize / 2;
        for (int x = -half; x <= half; x++)
        {
            for (int y = -half; y <= half; y++)
            {
                Vector2Int index = new Vector2Int(x, y);
                Vector3 pos = new Vector3(x * tileWidth, y * tileHeight, 0);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                tiles[index] = tile;
            }
        }

        UpdateTiles();
    }

    void Update()
    {
        UpdateTiles();
    }

    void UpdateTiles()
    {
        // Figure out which "tile index" the player is on
        int xIndex = Mathf.FloorToInt(player.position.x / tileWidth);
        int yIndex = Mathf.FloorToInt(player.position.y / tileHeight);

        Vector2Int newTileIndex = new Vector2Int(xIndex, yIndex);

        if (newTileIndex != currentTileIndex)
        {
            currentTileIndex = newTileIndex;
            RepositionTiles();
        }
    }

    void RepositionTiles()
    {
        int half = gridSize / 2;

        foreach (var kvp in tiles)
        {
            Vector2Int index = kvp.Key;
            GameObject tile = kvp.Value;

            Vector2Int worldIndex = currentTileIndex + index;
            Vector3 newPos = new Vector3(worldIndex.x * tileWidth, worldIndex.y * tileHeight, 0);
            tile.transform.position = newPos;

            // Hide tiles far away (outside grid)
            float distX = Mathf.Abs(worldIndex.x - currentTileIndex.x);
            float distY = Mathf.Abs(worldIndex.y - currentTileIndex.y);

            tile.SetActive(distX <= half && distY <= half);
        }
    }
}
