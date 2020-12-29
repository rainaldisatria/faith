using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "BackToHome", menuName = "State Machines/Actions/Back To Home")]
public class BackToHomeActionSO : StateActionSO<BackToHomeAction>
{ 

}

public class BackToHomeAction : StateAction
{
    private EnemyBattler _enemyBattler;
    private NavMeshAgent _nav;
    private BackToHome _originSO => (BackToHome)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _enemyBattler = stateMachine.GetComponent<EnemyBattler>();
        _nav = stateMachine.GetComponent<NavMeshAgent>();
    }

    public override void OnUpdate() 
    {
        _nav.SetDestination(_enemyBattler.Home);
    }
}
