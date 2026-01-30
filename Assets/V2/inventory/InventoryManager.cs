using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public static event Action<GameObject> OnSelectedItem;

    [SerializeField]
    private GameObject[] factory;

    [SerializeField] private PlayerInput playerInputAction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (playerInputAction != null)
            {
                
            }

            OnSelectedItem?.Invoke(factory[0]);
        }
    }


}
