﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsAttacking", menuName = "State Machines/Conditions/Is Attacking")]
public class IsAttackingConditionSO : StateConditionSO<IsAttackingCondition> { }

public class IsAttackingCondition : Condition
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    protected override bool Statement()
    {
        if(this._protagonist.attackInputPressed)
        {
            _protagonist.attackInputPressed = false;
            return true;
        }

        return false;
    }
}