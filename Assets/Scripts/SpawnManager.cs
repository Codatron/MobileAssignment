using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject targetPrefab;
    public GameObject[] targets;
    public Vector2 targetPos;

    private GridManager grid;
    private Tile tile;

    void Start()
    {
        grid = GameObject.Find("GridManager").GetComponent<GridManager>();

        SpawnMultiple(grid.gridStartPosP1, grid.width, grid.height);
        //SpawnTargets(grid.gridStartPosP1, grid.gridOffsetP1);
        //SpawnTargets(grid.gridStartPosP2, grid.gridOffsetP2);
    }

    public void SpawnSingle(int gridWidth, int gridHeight)
    {
        //int x = Random.Range(0, gridWidth);
        //int y = Random.Range(0, gridHeight);

        //Vector2 randomPos = new Vector2(x, y);

        //var targetToSpawn = Instantiate(targetPrefab, randomPos, Quaternion.identity);

        //targetPos = targetToSpawn.transform.position;
    }

    public void SpawnMultiple(Vector2Int offset, int w, int h)
    {
        int i = 0;

        while (i < targets.Length)
        {
            int x = Random.Range(0, w);
            int y = Random.Range(0, h);
           
            Vector2 randomPos = new Vector2(x, y);

            if (!grid.gridP1[x, y].GetComponent<Tile>().isOccupied)
            {
                var targetToSpawn = Instantiate(targets[i], randomPos + offset, Quaternion.identity);
                grid.gridP1[x, y].GetComponent<Tile>().ConnectToTarget(targetToSpawn);

                i++;
            }
        }
    }
}