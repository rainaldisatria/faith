using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ApplyPlayerMovement", menuName = "State Machines/Actions/Apply Player Movement")]
public class ApplyPlayerMovementSO : StateActionSO<ApplyPlayerMovementAction>
{ 
    
}

public class ApplyPlayerMovementAction : StateAction
{
    private Protagonist _protagonist;
    private CharacterController _cc;

    public override void Awake(StateMachine stateMachine)
    {
        this._protagonist = stateMachine.GetComponent<Protagonist>();
        this._cc = stateMachine.GetComponent<CharacterController>();
    }

    public override void OnUpdate()
    {
        this._cc.Move(this._protagonist.movementVector * Time.deltaTime);
    }
}
