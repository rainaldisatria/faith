using System;
using UnityEngine;

public class Protagonist : Battler
{
	[SerializeField] private InputReader _inputReader = default;
	[SerializeField] private ManagerSO _targetManagerSO;
	  
	[HideInInspector] public Vector3 movementInput;  
	[HideInInspector] public Vector3 movementVector;

	public FloatEventChannelSO OnHitted;
	public VoidEventChannelSO OnDead;

	private Vector2 _userInput;

	private void OnEnable()
	{ 
		_inputReader.MoveEvent += Move;
		_inputReader.AttackEvent += Attack;
		_inputReader.FirstSkillEvent += FirstSkill;
		_inputReader.SecondSkillEvent += SecondSkill;
	}
	 
	private void OnDisable()
	{ 
		_inputReader.MoveEvent -= Move;
		_inputReader.AttackEvent -= Attack;
		_inputReader.FirstSkillEvent -= FirstSkill;
		_inputReader.SecondSkillEvent -= SecondSkill; 
	} 

	private void Update()
	{
		CalculateMovement(); 
	}

	public override void TakeDamage(int damage, Transform damagerTrans)
	{
		base.TakeDamage(damage, damagerTrans);

		OnHitted.RaiseEvent((float)Data.HP / Data.MaxHP);

		this.transform.LookAt(damagerTrans);
		this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}

	protected override void Dead()
	{
		base.Dead();
		OnDead?.RaiseEvent();
	}

	#region Skills 
	private void FirstSkill()
	{
		Target = ((TargetManager)(_targetManagerSO.Manager)).CamTarget;
		IsUsingSkill = true;
		Skill = Data.Skills[0];
	}

	private void SecondSkill()
	{
		Target = ((TargetManager)(_targetManagerSO.Manager)).Target;
		IsUsingSkill = true;
		Skill = Data.Skills[1];
	}
	#endregion

	#region Input
	private void Move(Vector2 movement)
	{
		_userInput = movement;
	}

	public override void Attack() => isAttacking = true;
    #endregion

    #region Helper methods
    private void CalculateMovement()
	{
		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0f;
		Vector3 cameraRight = Camera.main.transform.right;
		cameraRight.y = 0f;

		Vector3 adjustedMovement = cameraRight.normalized * _userInput.x +
			cameraForward.normalized * _userInput.y;

		movementInput = Vector3.ClampMagnitude(adjustedMovement, 1f);
	}
    #endregion
}
