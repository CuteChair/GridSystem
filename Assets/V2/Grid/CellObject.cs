using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    public static event Action<Vector3> OnEnterCell;
    public static event Action OnLeaveCell;

    public NewCells CellInfo;

    public List<NewCells> CellConnection = new List<NewCells>();
    private void OnMouseEnter()
    {
        OnEnterCell?.Invoke(transform.position);
    }

    private void OnMouseExit()
    {
        OnLeaveCell();
    }
}
