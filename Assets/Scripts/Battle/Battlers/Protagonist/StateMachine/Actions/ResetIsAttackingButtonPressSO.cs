using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResetIsAttackingButtonPress", menuName = "State Machines/Actions/Reset Is Attacking Button Press")]
public class ResetIsAttackingButtonPressSO : StateActionSO<ResetIsAttackingButtonPressAction> { }

public class ResetIsAttackingButtonPressAction : StateAction
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnStateEnter()
    { 
        _protagonist.IsAttacking = false;
    }

    public override void OnUpdate(){}
}
