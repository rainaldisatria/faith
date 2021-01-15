using AnthaGames.Assets.Scripts.BattleSystem.Battlers.Protagonist; 
using UnityEngine;

[CreateAssetMenu(fileName = "HandlePlayerRotationWhenAttacking", menuName = "State Machines/Actions/Handle Player Rotation When Attacking")]
public class HandlePlayerRotationSOWhenAttackingSO : StateActionSO<HandlePlayerRotationSOWhenAttacking>
{
    public float turnSpeed = 15f;
}

public class HandlePlayerRotationSOWhenAttacking : StateAction
{
    private Protagonist _protagonist;
    private HandlePlayerRotationSO _originSO => (HandlePlayerRotationSO)base.OriginSO;
    private Vector3 faceDirection;

    public override void Awake(StateMachine stateMachine)
    {
        this._protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnStateEnter()
    { 
        faceDirection.x = _protagonist.movementInput.x;
        faceDirection.y = 0;
        faceDirection.z = _protagonist.movementInput.z;

        if (faceDirection != Vector3.zero)
            _protagonist.transform.forward = faceDirection;
    }

    public override void OnUpdate()
    { 

    }
}



