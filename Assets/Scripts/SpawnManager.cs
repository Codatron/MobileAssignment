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

        SpawnTargets(grid.gridStartPosP1, grid.gridOffsetP1);

        //SpawnTargets(grid.gridStartPosP2, grid.gridOffsetP2);
    }

    public void SpawnTarget(int gridWidth, int gridHeight)
    {
        //int x = Random.Range(0, gridWidth);
        //int y = Random.Range(0, gridHeight);

        //Vector2 randomPos = new Vector2(x, y);

        //var targetToSpawn = Instantiate(targetPrefab, randomPos, Quaternion.identity);

        //targetPos = targetToSpawn.transform.position;
    }

    public void SpawnTargets(Vector2Int gridStartPos, Vector2Int gridOffset)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            int x = Random.Range(gridStartPos.x, gridOffset.x);
            int y = Random.Range(gridStartPos.y, gridOffset.y);

            Vector2 randomPos = new Vector2(x, y);

            var targetToSpawn = Instantiate(targets[i], randomPos, Quaternion.identity);

            grid.gridP1[x, y].GetComponent<Tile>().ConnectToTarget(targetToSpawn);
        }
    }
}
