using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Cells defaultCell;

    public List<Cells> cellGrid = new List<Cells>();

    private Dictionary<int, Cells> cellsLink = new Dictionary<int, Cells>();

    public int rows;
    public int columns;

    public int IDDistributor;
    private void Start()
    {
        float currentXLoc = defaultCell.location.x;
        float currentYLoc = defaultCell.location.y;
        Vector2 newLoc = defaultCell.location;

        int rowCount = 0;

        for (int i = 0; i <= columns; i++)
        {

            if (i == columns)
            {
                currentXLoc = defaultCell.location.x;
                currentYLoc -= defaultCell.height;
                newLoc = new Vector2(currentXLoc, currentYLoc);

                i = 0;
                rowCount++;

                if (rowCount == rows)
                    return;
            }

            GameObject cell = Instantiate(defaultCell.cellObject, newLoc, Quaternion.identity);
            currentXLoc += defaultCell.width;
            newLoc = new Vector2 (currentXLoc, currentYLoc);

            IDDistributor++;

            Cells newCell = new Cells(IDDistributor, defaultCell.width, defaultCell.height, newLoc, cell, i + 1, rowCount + 1);

            AddCellToList(newCell);
        }
    }

    private void AddCellToList(Cells newCell)
    {
        cellGrid.Add(newCell);
        AddCellInfo(newCell, newCell.id);
    }

    private void AddCellInfo(Cells newCell, int id)
    {
        cellsLink.Add(id, newCell);
    }

    private void AddCellConnections(Cells newCell)
    {
        foreach (var cell in cellGrid)
        {

        }
    }
}
