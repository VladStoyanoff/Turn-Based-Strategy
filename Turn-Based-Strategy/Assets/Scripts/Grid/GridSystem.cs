using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    int width;
    int height;
    float cellSize;
    GridObject[,] gridObjectArray;

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] = new GridObject(this, gridPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) => new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    public GridObject GetGridObject(GridPosition gridPosition) => gridObjectArray[gridPosition.x, gridPosition.z];
    public GridPosition GetGridPosition(Vector3 worldPosition) => new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize), 
                                                                                   Mathf.RoundToInt(worldPosition.z / cellSize));
    public int GetWidth() => width;
    public int GetHeight() => height;


    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public bool IsValidGridPosition(GridPosition gridPosition) => gridPosition.x >= 0 &&
                                                                  gridPosition.z >= 0 &&
                                                                  gridPosition.x < width &&
                                                                  gridPosition.z < height;
}