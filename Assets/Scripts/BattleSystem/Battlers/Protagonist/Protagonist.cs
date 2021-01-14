﻿using System.Collections;
using UnityEngine;

namespace AnthaGames.Assets.Scripts.BattleSystem.Battlers.Protagonist
{
	public sealed class Protagonist : Battler
	{
		#region Depedency
		[SerializeField] private InputReader _inputReader = default;
		[SerializeField] private ManagerSO _targetManagerSO;
		#endregion

		#region State machine fields
		[HideInInspector] public Vector3 movementInput;
		[HideInInspector] public Vector3 movementVector;
		#endregion

		#region Fields
		private Vector2 _userInput;
		private int skillToUse;
		#endregion

		#region Events
		public FloatEventChannelSO OnHitted;
		public VoidEventChannelSO OnDead;
		#endregion

		#region Subscription 
		private void OnEnable()
		{
			_inputReader.MoveEvent += OnMove;
			_inputReader.AttackEvent += Attack;
			_inputReader.FirstSkillEvent += OnFirstSkill;
			_inputReader.SecondSkillEvent += OnSecondSkill;
		}

		private void OnDisable()
		{
			_inputReader.MoveEvent -= OnMove;
			_inputReader.AttackEvent -= Attack;
			_inputReader.FirstSkillEvent -= OnFirstSkill;
			_inputReader.SecondSkillEvent -= OnSecondSkill;
		}
		#endregion

		#region Behaviour 
		private void Update()
		{
			CalculateMovementInput();
		}

		public override void Attack()
		{
			IsAttacking = true;
		}

		protected override void Dead()
		{
			base.Dead();
			OnDead?.RaiseEvent();
		}

		#region Skills 
		public override void UseSkill()
		{
			StartCoroutine(Data.Skills[skillToUse].Execute(this, Target));
		}

		private void OnFirstSkill()
		{
			StartCoroutine(StartUseSkill());
			Target = ((TargetManager)(_targetManagerSO.Manager)).CamTarget;
			skillToUse = 0;
		}

		private void OnSecondSkill()
		{
			StartCoroutine(StartUseSkill());
			Target = ((TargetManager)(_targetManagerSO.Manager)).Target;
			skillToUse = 1;
		}

		private IEnumerator StartUseSkill()
		{
			yield return null;
			IsUsingSkill = true;
		}
		#endregion

		private void CalculateMovementInput()
		{
			Vector3 cameraForward = Camera.main.transform.forward;
			cameraForward.y = 0f;
			Vector3 cameraRight = Camera.main.transform.right;
			cameraRight.y = 0f;

			Vector3 adjustedMovement = cameraRight.normalized * _userInput.x +
				cameraForward.normalized * _userInput.y;

			movementInput = Vector3.ClampMagnitude(adjustedMovement, 1f);
		}

		private void OnMove(Vector2 movement)
		{
			_userInput = movement;
		}
		#endregion

		#region IDamageable
		public override void TakeDamage(int damage, Transform damagerTrans)
		{
			base.TakeDamage(damage, damagerTrans);

			OnHitted.RaiseEvent((float)Data.HP / Data.MaxHP);

			this.transform.LookAt(damagerTrans);
			this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}
		#endregion
	}
}
