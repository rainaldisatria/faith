using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChasePlayer", menuName = "State Machines/Actions/Chase Player")]
public class ChasePlayerActionSO : StateActionSO<ChasePlayerAction> 
{ 

}

public class ChasePlayerAction : StateAction
{
    private NavMeshAgent _battler;
    private Transform _playerTrans;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<NavMeshAgent>();
        _playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public override void OnUpdate()
    {
        _battler.SetDestination(_playerTrans.position);
    }
}
