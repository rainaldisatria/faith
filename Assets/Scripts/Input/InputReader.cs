using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName="InputReader", menuName ="Input/InputReader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{
    // Gameplay
    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction MoveStarted;
    public event UnityAction MoveCanceled;
    public event UnityAction MovePerformed;
    public event UnityAction AttackEvent;
    public event UnityAction InteractEvent;
    public event UnityAction PauseEvent;
    public event UnityAction<Vector2> CameraEvent;

    private GameInput gameInput;

    private void OnEnable()
    {
        if(gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Enable();

            gameInput.Gameplay.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        gameInput.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            AttackEvent?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            InteractEvent?.Invoke();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            PauseEvent?.Invoke();
    }

    public void OnCameraMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            CameraEvent?.Invoke(context.ReadValue<Vector2>());
    }
}
