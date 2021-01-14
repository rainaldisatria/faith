using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "LookAtPlayer", menuName = "State Machines/Actions/Look At Player")]
public class LookAtPlayerActionSO : StateActionSO<LookAtPlayerAction>
{

}

public class LookAtPlayerAction : StateAction
{
    private Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    private Transform enemyTransform;

    public override void Awake(StateMachine stateMachine)
    {
        enemyTransform = stateMachine.transform;
    }

    public override void OnUpdate()
    {
        enemyTransform.LookAt(playerTransform);
        enemyTransform.eulerAngles = new Vector3(0, enemyTransform.eulerAngles.y, 0);
    }
}


