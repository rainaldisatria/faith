using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName="InputReader", menuName ="Input/InputReader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IDialogueActions
{
    // Gameplay
    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction MoveStarted;
    public event UnityAction MoveCanceled;
    public event UnityAction MovePerformed;
    public event UnityAction AttackEvent;
    public event UnityAction FirstSkillEvent;
    public event UnityAction SecondSkillEvent;
    public event UnityAction ThirdSkillEvent;
    public event UnityAction InteractEvent;
    public event UnityAction PauseEvent;
    public event UnityAction<Vector2> CameraEvent;
 

    // Dialogue
    public event UnityAction AdvanceDialogue;

    private GameInput gameInput;

    private void OnEnable()
    {
        if(gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Enable();

            gameInput.Gameplay.SetCallbacks(this);
            gameInput.Dialogue.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        EnableGameplayInput();
    }

    public void EnableGameplayInput()
    {
        gameInput.Gameplay.Enable();
        gameInput.Dialogue.Disable();
    }

    public void EnableDialogueInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Dialogue.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
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

    public void OnAdvanceDialogue(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            AdvanceDialogue?.Invoke();
        }
    }

    public void OnFirstSkill(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            FirstSkillEvent?.Invoke();
        }
    }

    public void OnSecondSkill(InputAction.CallbackContext context)
    { 
        if (context.phase == InputActionPhase.Started)
        {
            SecondSkillEvent?.Invoke();
        }
    }

    public void OnThirdSkill(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            ThirdSkillEvent?.Invoke();
        }
    }
}
