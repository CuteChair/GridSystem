using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{

    private Camera p_camera;

    [SerializeField]
    private float moveSpeed;

    private Vector3 newDirection = Vector3.zero;

    [SerializeField]
    private float zoomSens;

    private void Awake()
    {
        p_camera = GetComponent<Camera>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        newDirection = new Vector3(moveInput.x, moveInput.y, 0f);
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        Vector2 scrollInput = context.ReadValue<Vector2>();

        float camSizeMod = 0;

        if (scrollInput.y > 0)
        {
            camSizeMod = 1;
        }
        if(scrollInput.y < 0)
        {
            camSizeMod = -1;
        }

        p_camera.orthographicSize += camSizeMod * zoomSens;


        
    }

    private void Update()
    {
        transform.Translate(newDirection * moveSpeed * Time.deltaTime);
    }
}
