﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsAttacking", menuName = "State Machines/Conditions/Is Attacking")]
public class IsAttackingConditionSO : StateConditionSO<IsAttackingCondition> { }

public class IsAttackingCondition : Condition
{
    private Battler _battler;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<Battler>();
    }

    protected override bool Statement()
    {
        if(this._battler.isAttacking)
        {
            if(_battler is Protagonist)
                _battler.isAttacking = false;
            return true;
        }

        return false;
    }
}