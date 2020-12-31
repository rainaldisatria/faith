using System;
using UnityEngine;

/// <summary>
/// <para>This component consumes input on the InputReader and stores its values. The input is then read, and manipulated, by the StateMachines's Actions.</para>
/// </summary>
public class Protagonist : Battler
{
	[SerializeField] private InputReader _inputReader = default; 

	private Vector2 _previousMovementInput;
	  
	[HideInInspector] public Vector3 movementInput;  
	[HideInInspector] public Vector3 movementVector;

	public FloatEventChannelSO OnHitted;
	public VoidEventChannelSO OnDead;
	 
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

	public override void TakeDamage(int damage, Transform damagerTrans)
	{
		base.TakeDamage(damage, damagerTrans);

		OnHitted.RaiseEvent((float)Data.HP / Data.MaxHP);

		this.transform.LookAt(damagerTrans);
		transform.eulerAngles = new Vector3(0, damagerTrans.eulerAngles.y, 0); 
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		OnDead?.RaiseEvent();
	}

	#region Input
	private void OnMove(Vector2 movement)
	{
		_previousMovementInput = movement;
	}

	public override void OnAttack() => isAttacking = true;
    #endregion

    #region Helper methods
    private void RecalculateMovement()
	{
		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0f;
		Vector3 cameraRight = Camera.main.transform.right;
		cameraRight.y = 0f;

		Vector3 adjustedMovement = cameraRight.normalized * _previousMovementInput.x +
			cameraForward.normalized * _previousMovementInput.y;

		movementInput = Vector3.ClampMagnitude(adjustedMovement, 1f);
	}
    #endregion
}
