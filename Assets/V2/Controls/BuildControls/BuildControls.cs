using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildControls : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedBuilding;

    private Camera p_Camera;
    private float mouseX => Input.mousePosition.x;
    private float mouseY => Input.mousePosition.y;
    private Vector3 mousePosToWorld => p_Camera.ScreenToWorldPoint(new Vector3(mouseX, mouseY, p_Camera.nearClipPlane));

    private bool isLocked;

    private void Awake()
    {
        p_Camera = GetComponent<Camera>();
    }

    public void OnLMBPressed(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        print("Click");

        if(selectedBuilding == null)
            return;

        Vector2 pos = new Vector2(selectedBuilding.transform.position.x, selectedBuilding.transform.position.y);

        if (NewGridManager.Instance.RequestBuild(pos))
        {
            GameObject newObject = Instantiate(selectedBuilding, pos, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        InventoryManager.OnSelectedItem += SelectItem;
        CellObject.OnEnterCell += OnEnterCell;
        CellObject.OnLeaveCell += OnLeftCell;
    }

    private void OnDisable()
    {
        InventoryManager.OnSelectedItem += SelectItem;
        CellObject.OnEnterCell += OnEnterCell;
        CellObject.OnLeaveCell += OnLeftCell;
    }

    private void Update()
    {
        if (selectedBuilding != null && !isLocked)
        {
            selectedBuilding.transform.position = mousePosToWorld;
        }
    }


    private void SelectItem(GameObject newItem)
    {
        if (selectedBuilding == newItem)
            return;

        selectedBuilding = newItem;

        CreateBuildSchematic();
    }

    private void CreateBuildSchematic()
    { 
        GameObject itemSchematic = Instantiate(selectedBuilding, mousePosToWorld, Quaternion.identity);

        selectedBuilding = itemSchematic;
    }

    private void OnEnterCell(Vector3 snapPos)
    {
        if (selectedBuilding == null)
            return;
        isLocked = true;
        selectedBuilding.transform.position = snapPos;
    }

    private void OnLeftCell()
    {
        if (selectedBuilding == null)
            return;
        isLocked = false;
    }
}
