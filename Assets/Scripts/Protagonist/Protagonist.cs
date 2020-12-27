using System;
using UnityEngine;

/// <summary>
/// <para>This component consumes input on the InputReader and stores its values. The input is then read, and manipulated, by the StateMachines's Actions.</para>
/// </summary>
public class Protagonist : MonoBehaviour
{
	[SerializeField] private InputReader _inputReader = default; 

	private Vector2 _previousMovementInput;

	//These fields are read and manipulated by the StateMachine actions
	[HideInInspector] public bool jumpInput;
	[HideInInspector] public bool extraActionInput;
	[HideInInspector] public Vector3 movementInput; //Initial input coming from the Protagonist script
	[HideInInspector] public Vector3 movementVector; //Final movement vector, manipulated by the StateMachine actions
	[HideInInspector] public ControllerColliderHit lastHit;
	[HideInInspector] public bool isRunning; // Used when using the keyboard to run, brings the normalised speed to 1 

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		lastHit = hit;
	}

	//Adds listeners for events being triggered in the InputReader script
	private void OnEnable()
	{ 
		_inputReader.MoveEvent += OnMove;  
	}

	//Removes all listeners to the events coming from the InputReader script
	private void OnDisable()
	{ 
		_inputReader.MoveEvent -= OnMove;  
	}

	private void Update()
	{
		RecalculateMovement();
	}

	private void RecalculateMovement()
	{
		//Get the two axes from the camera and flatten them on the XZ plane
		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0f;
		Vector3 cameraRight = Camera.main.transform.right;
		cameraRight.y = 0f;

		//Use the two axes, modulated by the corresponding inputs, and construct the final vector
		Vector3 adjustedMovement = cameraRight.normalized * _previousMovementInput.x +
			cameraForward.normalized * _previousMovementInput.y;

		movementInput = Vector3.ClampMagnitude(adjustedMovement, 1f);


		// This is used to set the speed to the maximum if holding the Shift key,
		// to allow keyboard players to "run"
		if (isRunning)
			movementInput.Normalize();
	}

	//---- EVENT LISTENERS ----

	private void OnMove(Vector2 movement)
	{
		_previousMovementInput = movement;
	} 
}
