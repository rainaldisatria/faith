using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChasePlayer", menuName = "State Machines/Actions/Chase Player")]
public class ChasePlayerActionSO : StateActionSO<ChasePlayerAction> 
{
    public float Treshold = 4;
}

public class ChasePlayerAction : StateAction
{
    private NavMeshAgent _battler;
    private Transform _playerTrans;
    private ChasePlayerActionSO _originSO => (ChasePlayerActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<NavMeshAgent>();
        _playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public override void OnUpdate()
    { 
        if (Vector3.Distance(_battler.transform.position, _playerTrans.position) > 4)
        {
            _battler.SetDestination(_playerTrans.position - _battler.transform.forward * _originSO.Treshold); 
        }
        else
        {
            _battler.SetDestination(_battler.transform.position);
        }
    }
}
