using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Vector2 inputVector;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVector()
    {
        inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
