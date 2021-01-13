using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwitchAnimatorParameter", menuName = "State Machines/Actions/Switch Animator Parameter")]
public class SwitchAnimatorParameterSO : StateActionSO
{ 
	public string parameterName = default; 
	public bool boolValue = default; public StateAction.SpecificMoment whenToRun = default; // Allows this StateActionSO type to be reused for all 3 state moments

	protected override StateAction CreateAction() => new SwitchAnimatorParameterAction(Animator.StringToHash(parameterName));
}

public class SwitchAnimatorParameterAction : StateAction
{
	private Animator[] _animators;
	private Protagonist _protagonist;
	private SwitchAnimatorParameterSO _originSO => (SwitchAnimatorParameterSO)base.OriginSO;
	private int _parameterHash;

	public SwitchAnimatorParameterAction(int parameterHash)
	{
		_parameterHash = parameterHash;
	}

	public override void Awake(StateMachine stateMachine)
	{
		_animators = stateMachine.GetComponentsInChildren<Animator>();
		_protagonist = stateMachine.GetComponent<Protagonist>();
	}

	public override void OnStateEnter()
	{
		if (_originSO.whenToRun == SpecificMoment.OnStateEnter)
			_protagonist.StartCoroutine(SetParameter());
	}

	public override void OnStateExit()
	{
		if (_originSO.whenToRun == SpecificMoment.OnStateExit)
			_protagonist.StartCoroutine(SetParameter());
	}

	private void SetAllAnimators(Action<int> action)
	{
		for (int i = 0; i < this._animators.Length; i++)
		{
			action(i);
		}
	}

	private IEnumerator SetParameter()
	{
		SetAllAnimators((i) => _animators[i].SetBool(_parameterHash, _originSO.boolValue)); 
		yield return null; 
		SetAllAnimators((i) => _animators[i].SetBool(_parameterHash, !_originSO.boolValue)); 
	}

	public override void OnUpdate() { }
}
