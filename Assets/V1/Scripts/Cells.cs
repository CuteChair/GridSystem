using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class Cells 
{
    public int id;
    public float width;
    public float height;
    public Vector2 location;
    public GameObject cellObject;
    public int atRow;
    public int atColumn;

    public List<int> connections = new List<int>();

    public Cells(int id, float width, float height, Vector2 location, GameObject cellObject,int atColumn , int atRow)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.location = location;
        this.cellObject = cellObject;
        this.atColumn = atColumn;
        this.atRow = atRow;
    }
}
