using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    public NewCells CellInfo;

    public List<NewCells> CellConnection = new List<NewCells>();
    private void OnMouseEnter()
    {
        print("Mouse on : " + CellInfo.CoordinateLoc.Row + " : " + CellInfo.CoordinateLoc.Column);
    }
}
