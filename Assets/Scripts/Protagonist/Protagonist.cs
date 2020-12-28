using System;
using UnityEngine;

/// <summary>
/// <para>This component consumes input on the InputReader and stores its values. The input is then read, and manipulated, by the StateMachines's Actions.</para>
/// </summary>
public class Protagonist : Battler
{
	[SerializeField] private InputReader _inputReader = default; 

	private Vector2 _previousMovementInput;
	 
	[HideInInspector] public bool jumpInput;
	 public bool attackInputPressed;
	[HideInInspector] public Vector3 movementInput;  
	[HideInInspector] public Vector3 movementVector;  
	[HideInInspector] public ControllerColliderHit lastHit;
	[HideInInspector] public bool isRunning;  

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		lastHit = hit;
	}
	 
	private void OnEnable()
	{ 
		_inputReader.MoveEvent += OnMove;
		_inputReader.AttackEvent += OnAttack;
	}
	 
	private void OnDisable()
	{ 
		_inputReader.MoveEvent -= OnMove;
		_inputReader.AttackEvent -= OnAttack;
	}

	private void Update()
	{
		RecalculateMovement();
	}

	private void RecalculateMovement()
	{ 
		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0f;
		Vector3 cameraRight = Camera.main.transform.right;
		cameraRight.y = 0f;
		 
		Vector3 adjustedMovement = cameraRight.normalized * _previousMovementInput.x +
			cameraForward.normalized * _previousMovementInput.y;

		movementInput = Vector3.ClampMagnitude(adjustedMovement, 1f);

		if (isRunning)
			movementInput.Normalize();
	}

	//---- EVENT LISTENERS ----

	private void OnMove(Vector2 movement)
	{
		_previousMovementInput = movement;
	}

	public override void OnAttack() => attackInputPressed = true; 

	protected override void OnDeath()
	{
		 
	} 
}
