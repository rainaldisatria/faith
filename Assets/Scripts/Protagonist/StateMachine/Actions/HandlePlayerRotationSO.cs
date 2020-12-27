using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HandlePlayerRotation", menuName = "State Machines/Actions/Handle Player Rotation")]
public class HandlePlayerRotationSO : StateActionSO<HandlePlayerRotationAction>
{
    public float turnSpeed = 15f;
}

public class HandlePlayerRotationAction : StateAction
{
    private Protagonist _protagonist;
    private HandlePlayerRotationSO _originSO => (HandlePlayerRotationSO)base.OriginSO;
    private Vector3 faceDirection;

    public override void Awake(StateMachine stateMachine)
    {
        this._protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnUpdate()
    {
        faceDirection.x = _protagonist.movementInput.x;
        faceDirection.y = 0;
        faceDirection.z = _protagonist.movementInput.z;

        _protagonist.transform.forward = Vector3.Slerp(_protagonist.transform.forward.normalized,
            -faceDirection, _originSO.turnSpeed * Time.deltaTime);
    }
}



