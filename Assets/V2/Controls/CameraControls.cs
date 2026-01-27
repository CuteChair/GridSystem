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

    [SerializeField]
    private float minOrtSize;

    [SerializeField]
    private float maxOrtSize;

    float camSizeMod;

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
        float scrollY = context.ReadValue<Vector2>().y;

        float ortSizeMult = Mathf.Clamp(scrollY, -1f, 1f);

        p_camera.orthographicSize = Mathf.Clamp(
            p_camera.orthographicSize - ortSizeMult * zoomSens,
            minOrtSize,
            maxOrtSize
            );
    }

    private void Update()
    {
        transform.Translate(newDirection * moveSpeed * Time.deltaTime);
    }

}
