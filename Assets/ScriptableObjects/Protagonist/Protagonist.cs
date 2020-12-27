using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.InputSystem;

public class Protagonist : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private bool IsGrounded => Physics.Raycast(transform.position, -Vector3.up,  0.1f);
    private bool IsAlmostGrounded => Physics.Raycast(transform.position, -Vector3.up, 1f);

    private CharacterController _cc;

    private Animator[] _animators;
    private Vector2 _previousMovementInput;
    private Vector3 cameraForward;
    private Vector3 cameraRight;
    private Vector3 adjustedMovement; 
    private float vSpeed;

    private bool isMoving = false;

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
        _cc = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
        _inputReader.AttackEvent += OnAttack;
    }

    private void Update()
    { 
        CalculateMovement();
        DetermineAnimationToPlay();
    }

    public void OnMoveStarted()
    {
        SetBoolean(true, "isWalking");
    }

    public void OnMoveCanceled()
    {
        SetBoolean(false, "isWalking");
    }

    private void SetInteger(int value, string name = "condition")
    {
        for(int i = 0; i < _animators.Length; i++)
        {
            _animators[i].SetInteger(name, value);
        }
    }

    private void SetBoolean(bool value, string name)
    {
        for(int i = 0; i < _animators.Length; i++)
        {
            _animators[i].SetBool(name, value);
        }
    }

    #region Helper methods
    private void DetermineAnimationToPlay()
    {
        if (isMoving)
        {
            OnMoveStarted();
        }
        else
        {
            OnMoveCanceled();
        }
    }

    private void CalculateMovement()
    {
        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;

        cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;

        adjustedMovement = cameraRight.normalized * _previousMovementInput.x +
            cameraForward.normalized * _previousMovementInput.y;

        if (adjustedMovement != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward.normalized, -adjustedMovement, 10 * Time.deltaTime);
        }

        if (IsGrounded)
        {
            vSpeed = 0;
        }

        vSpeed -= 0.9f * Time.deltaTime;
        adjustedMovement.y = vSpeed;


        _cc.Move(adjustedMovement * Time.deltaTime * 10);

        if (adjustedMovement.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }  

    private void OnMove(Vector2 movement)
    { 
        _previousMovementInput = movement;
    }

    private void OnAttack()
    {
        Debug.Log("Attack called");
        SetBoolean(true, "isAttacking");
    }
    #endregion
}
