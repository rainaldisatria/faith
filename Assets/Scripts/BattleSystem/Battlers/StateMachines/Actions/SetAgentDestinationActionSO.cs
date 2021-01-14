using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "SetAgentDestination", menuName = "State Machines/Actions/Set Agent Destination")]
public class SetAgentDestinationActionSO : StateActionSO<SetAgentDestinationAction>
{ 

}

public class SetAgentDestinationAction : StateAction
{
    private NavMeshAgent _navMeshAgent;
    private Transform _currentTrans;

    public override void Awake(StateMachine stateMachine)
    {
        _navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        _currentTrans = stateMachine.transform;
    }

    public override void OnStateEnter()
    {
        _navMeshAgent.SetDestination(_currentTrans.position);
    }

    public override void OnUpdate()
    {

    }
}
