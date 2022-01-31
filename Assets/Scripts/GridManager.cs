using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject[,] grid;
    public GameObject[,] gridP1;
    public GameObject[,] gridP2;

    public int width;
    public int height;
    public int widthOffset;
    public Vector2Int gridStartPosP1;
    public Vector2Int gridOffsetP1;
    public Vector2Int gridStartPosP2;
    public Vector2Int gridOffsetP2;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Camera cam;

    void Start()
    {
        GenerateGrid(width, height, gridStartPosP1);

        // TODO: Object out of range exception when gridP2 and SpawnP2 are on...WHY???
        //GenerateGrid(width, height, gridStartPosP2);  

        // Adjusts the camera so that 0, 0 is in the bottom left corner (almost)
        //cam.transform.position = new Vector3(width / 2, (height / 2) + height, -10f); 
    }

    public void GenerateGrid(int w, int h, Vector2Int sPos)
    {
        gridP1 = new GameObject[w, h];
        
        gridOffsetP1.x = sPos.x;
        gridOffsetP1.y = sPos.y;

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                gridP1[x, y] = Instantiate(tilePrefab, new Vector2(x + gridOffsetP1.x, y + gridOffsetP1.y), Quaternion.identity);
                gridP1[x, y].name = $"Tile {x + gridOffsetP1.x} {y + gridOffsetP1.y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                gridP1[x, y].GetComponent<Tile>().SetColor(isOffset);
            }
        }
    }

    //private void GenerateGrid()
    //{
    //    grid = new GameObject[width, height];

    //    for (int x = 0; x < width; x++)
    //    {
    //        for (int y = 0; y < height; y++)
    //        {
    //            grid[x, y] = Instantiate(tilePrefab, new Vector2(x - (width / 2), y + (height / 2)), Quaternion.identity);

    //            var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
    //            grid[x, y].GetComponent<Tile>().SetColor(isOffset);
    //        }
    //    }
    //}

    //private void GenerateGridPlayerOne()
    //{
    //    gridP1 = new GameObject[width, height];


    //    for (int x = 0; x < width; x++)
    //    {
    //        for (int y = 0; y < height; y++)
    //        {
    //            gridP1[x, y] = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
    //            gridP1[x, y].name = $"P1 Tile {x} {y}";

    //            var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
    //            gridP1[x, y].GetComponent<Tile>().SetColor(isOffset);
    //        }
    //    }
    //}

    //private void GenerateGridPlayerTwo()
    //{
    //    gridP2 = new GameObject[width, height];

    //    for (int x = 0; x < width; x++)
    //    {
    //        for (int y = 0; y < height; y++)
    //        {
    //            gridP2[x, y] = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
    //            gridP2[x, y].name = $"P2 Tile {x} {y}";

    //            var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
    //            gridP2[x, y].GetComponent<Tile>().SetColor(isOffset);
    //        }
    //    }
    //}
}

//var tileClone = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
//tileClone.name = $"Tile {x} {y}";
//tileClone.SetColor(isOffset);


