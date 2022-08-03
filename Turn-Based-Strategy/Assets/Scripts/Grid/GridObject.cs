using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    [Header("Grid")]
    GridSystem gridSystem;
    GridPosition gridPosition;

    [Header("Lists")]
    List<Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public override string ToString()
    {
        string unitString = "";
        foreach(Unit unit in unitList)
        {
            unitString += unit + "\n";
        }
        return gridPosition.ToString() + "\n" + unitString;
    }

       
    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public List<Unit> GetUnitList() => unitList;
    public bool HasAnyUnit() => unitList.Count > 0;
}