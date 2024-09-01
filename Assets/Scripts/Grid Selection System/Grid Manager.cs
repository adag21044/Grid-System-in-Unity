using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {
        DetectTileClick();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var SpawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                SpawnedTile.name = $"Tile {x} {y}";

                var isOffset = ((x % 2 == 0) && (y % 2 == 0)) || ((x % 2 != 0) && (y % 2 != 0));
                SpawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = SpawnedTile;

            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    void DetectTileClick()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click detection
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gridPosition = new Vector2(Mathf.RoundToInt(mousePosition.x), Mathf.RoundToInt(mousePosition.y));

            Tile clickedTile = GetTileAtPosition(gridPosition);
            if (clickedTile != null)
            {
                Debug.Log($"Clicked on: {clickedTile.name} at position {gridPosition}");
            }
            else
            {
                Debug.Log("No tile found at this position.");
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos, out var tile)) return tile;
        else return null;
    }
}
