using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIsInHome", menuName = "State Machines/Conditions/Enemy Is In Home")]
public class EnemyIsInHomeConditionSO : StateConditionSO<EnemyIsInHomeCondition> { }

public class EnemyIsInHomeCondition : Condition
{
    private EnemyBattler _enemyBattler;

    public override void Awake(StateMachine stateMachine)
    {
        _enemyBattler = stateMachine.GetComponent<EnemyBattler>();
    }

    protected override bool Statement()
    {
        if (Vector3.Distance(_enemyBattler.transform.position, _enemyBattler.Home) <= 0.01f)
        {
            return true;
        }

        return false;
    }
}