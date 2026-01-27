using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellConnectionManager : MonoBehaviour
{
    private Dictionary<int, CellObject> cells = new Dictionary<int, CellObject>();
    private List<CellObject> cellObjects = new List<CellObject>();

    private void OnEnable()
    {
        NewGridManager.OnNewCellCreated += AddNewCell;
        NewGridManager.OnWholeGridGenerated += CreateCellConnections;
    }

    private void OnDisable()
    {
        NewGridManager.OnNewCellCreated += AddNewCell;
        NewGridManager.OnWholeGridGenerated -= CreateCellConnections;
    }

    private void AddNewCell(int id, CellObject newCell)
    {
        cells.Add(id, newCell);
    }

    private void CreateCellConnections(int row, int column)
    {
        List<NewCells> newCells = new List<NewCells>();


       for (int i = 0; i < cells.Count; i++)
        {
            //if (cells.ContainsKey(cells[i].CellInfo.ID - 1) && cells[i].CellInfo.CoordinateLoc.Column != 0)
            if (cells.ContainsKey(cells[i].CellInfo.ID - 1))
            {
                newCells.Add(cells[i - 1].CellInfo);
            }

            //if (cells.ContainsKey(cells[i].CellInfo.ID + 1) && cells[i].CellInfo.CoordinateLoc.Column != column - 1)
            if (cells.ContainsKey(cells[i].CellInfo.ID + 1) && cells[i].CellInfo.CoordinateLoc.Column != column)
            {
                newCells.Add(cells[i + 1].CellInfo);
            }

            if (cells.ContainsKey(cells[i].CellInfo.ID + column))
            {
                newCells.Add(cells[i + column].CellInfo);
            }

            if (cells.ContainsKey(cells[i].CellInfo.ID - column))
            {
                newCells.Add(cells[i - column].CellInfo);
            }

            cells[i].CellConnection = newCells;

            newCells = new List<NewCells>();
        }
    }
}
