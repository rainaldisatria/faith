using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_SetChasing", menuName = "State Machines/Actions/Enemy_Set Chasing")]
public class SetChasingActionSO : StateActionSO<SetChasingToTrueAction>
{
    public StateAction.SpecificMoment moment;
    public bool value;
}

public class SetChasingToTrueAction : StateAction
{
    private EnemyBattler _enemyBattler;
    private SetChasingActionSO _originSO => (SetChasingActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _enemyBattler = stateMachine.GetComponent<EnemyBattler>();
    }

    public override void OnStateEnter()
    {
        if(_originSO.moment == SpecificMoment.OnStateEnter)
            _enemyBattler.isChasing = _originSO.value;
    }

    public override void OnStateExit()
    {
        if (_originSO.moment == SpecificMoment.OnStateExit)
            _enemyBattler.isChasing = _originSO.value;
    }

    public override void OnUpdate() { }
}
