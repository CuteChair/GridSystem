using System;
using System.Collections.Generic;
using UnityEngine;

public class NewGridManager : MonoBehaviour
{
    public static NewGridManager Instance;

    public static event Action<int, CellObject> OnNewCellCreated;
    public static event Action<int, int> OnWholeGridGenerated;

    public int Height;
    public int Width;

    public int Rows;
    public int Columns;

    public GameObject CellsPrefab;

    public Vector2 currentLoc = Vector2.zero;

    private Dictionary<Vector2, bool> posInGrid = new Dictionary<Vector2, bool>();
    //public HashSet<Vector2> posInGrid = new HashSet<Vector2>();


    private void Awake()
    {
        Instance = this;
    }
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
                {
                    OnWholeGridGenerated?.Invoke(Rows, Columns);
                    return;
                }
            }

            posInGrid.Add(currentLoc, false);

            CreateNewCell(currentLoc, id, rowCount + 1, i + 1);

            currentLoc.x += Width;

            id++;
        }
    }

    private void CreateNewCell(Vector2 newPos, int id, int atRow, int AtCol)
    {
        GameObject newCell = Instantiate(CellsPrefab, newPos, Quaternion.identity);

        CellObject newCellComponent = newCell.gameObject.AddComponent<CellObject>();

        newCellComponent.CellInfo = new NewCells(id, atRow, AtCol);

        OnNewCellCreated?.Invoke(id , newCellComponent);
    }

    public bool RequestBuild(Vector2 newPos)
    {
        if (posInGrid.ContainsKey(newPos))
        {
            return true;
        }
        else
            return false;
    }

}
