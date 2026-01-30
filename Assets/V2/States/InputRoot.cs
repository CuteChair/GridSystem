using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRoot : MonoBehaviour
{
    public static InputRoot Instance;

    public PlayerInputActions actions;

    private void Awake()
    {
        Instance = this;

        actions = new PlayerInputActions();

        actions.Gameplay.Enable();

        //actions.Build.Enable();

        foreach (var action in actions)
        {
            print($"{action.name} : {action.enabled}");
        }
    }
}
