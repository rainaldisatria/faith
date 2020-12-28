using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPlayer", menuName = "State Machines/Actions/Attack Player")]
public class AttackPlayerActionSO : StateActionSO<AttackPlayerAction>
{ 

}

public class AttackPlayerAction : StateAction
{
    private EnemyBattler _enemyBattler;

    public override void Awake(StateMachine stateMachine)
    {
        _enemyBattler = stateMachine.GetComponent<EnemyBattler>();
    }

    public override void OnUpdate()
    {
        _enemyBattler.OnAttack();
    }
}
