using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsMoving", menuName = "State Machines/Conditions/Is Moving")]
public class IsMovingConditionSO : StateConditionSO
{
    [SerializeField] private float _treshold = 0.2f;

    protected override Condition CreateCondition()
    {
        return new IsMovingCondition();
    }
}

public class IsMovingCondition : Condition
{
    private float _treshold;
    private CharacterController _cc;

    public override void Awake(StateMachine stateMachine)
    {
        _cc = stateMachine.GetComponent<CharacterController>();
    }

    protected override bool Statement()
    {
        return _cc.velocity.sqrMagnitude > _treshold * _treshold;
    }
}
