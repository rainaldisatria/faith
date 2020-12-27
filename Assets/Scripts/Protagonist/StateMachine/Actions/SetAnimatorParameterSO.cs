using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetAnimatorParameter", menuName = "State Machines/Actions/Set Animator Parameter")]
public class SetAnimatorParameterSO : StateActionSO
{
	public ParameterType parameterType = default;
	public string parameterName = default;

	public bool boolValue = default;
	public int intValue = default;
	public float floatValue = default;

	public  StateAction.SpecificMoment whenToRun = default; // Allows this StateActionSO type to be reused for all 3 state moments

	protected override StateAction CreateAction() => new SetAnimatorParameterAction(Animator.StringToHash(parameterName));

	public enum ParameterType
	{
		Bool, Int, Float, Trigger,
	}
}

public class SetAnimatorParameterAction : StateAction
{
	private Animator[] _animators;
	private SetAnimatorParameterSO _originSO => (SetAnimatorParameterSO)base.OriginSO;
	private int _parameterHash;

	public SetAnimatorParameterAction(int parameterHash)
	{
		_parameterHash = parameterHash;
	}

	public override void Awake(StateMachine stateMachine)
	{
		_animators = stateMachine.GetComponentsInChildren<Animator>();
	}

	public override void OnStateEnter()
	{
		if (_originSO.whenToRun == SpecificMoment.OnStateEnter)
			SetParameter();
	}

	public override void OnStateExit()
	{
		if (_originSO.whenToRun == SpecificMoment.OnStateExit)
			SetParameter();
	}

	private void SetAllAnimators(Action<int> action)
	{
		for(int i = 0; i < this._animators.Length; i++)
		{
			action(i);
		}
	}

	private void SetParameter()
	{
		switch (_originSO.parameterType)
		{
			case SetAnimatorParameterSO.ParameterType.Bool:
				SetAllAnimators((i) => _animators[i].SetBool(_parameterHash, _originSO.boolValue));
				break;
			case SetAnimatorParameterSO.ParameterType.Int:
				SetAllAnimators((i) => _animators[i].SetInteger(_parameterHash, _originSO.intValue));
				break;
			case SetAnimatorParameterSO.ParameterType.Float:
				SetAllAnimators((i) => _animators[i].SetFloat(_parameterHash, _originSO.floatValue));
				break;
			case SetAnimatorParameterSO.ParameterType.Trigger:
				SetAllAnimators((i) => _animators[i].SetTrigger(_parameterHash));
				break;
		}
	}

	public override void OnUpdate() {}
}
