using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NewCells 
{
    public int ID;
    public CellCoordinates CoordinateLoc;
    public NewCells(int id, int atRow, int atCol)
    {
        CoordinateLoc = new CellCoordinates();

        ID = id;

        CoordinateLoc.Row = atRow;
        CoordinateLoc.Column = atCol;
    }
}
