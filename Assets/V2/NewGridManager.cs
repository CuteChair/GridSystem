using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGridManager : MonoBehaviour
{
    public int Height;
    public int Width;

    public int Rows;
    public int Columns;

    public GameObject CellsPrefab;

    public Vector2 currentLoc = Vector2.zero;
    public List<Vector2> PosInGrid = new List<Vector2>();

    private void Start()
    {
        int rowCount = 0;
        int id = 0;

        for(int i = 0; i <= Columns; i++)
        {
            if(i == Columns)
            {
                currentLoc.y -= Height;
                currentLoc.x = 0f;

                rowCount++;
                i = 0;

                if (rowCount == Rows)
                    return;
            }

            PosInGrid.Add(currentLoc);

            CreateNewCell(currentLoc, id, rowCount, i);

            currentLoc.x += Width;

            id++;
        }
    }

    private void CreateNewCell(Vector2 newPos, int id, int atRow, int AtCol)
    {
        GameObject newCell = Instantiate(CellsPrefab, newPos, Quaternion.identity);

        CellObject newCellComponent = newCell.gameObject.AddComponent<CellObject>();

        newCellComponent.CellInfo = new NewCells(id, atRow, AtCol);
    }

}
