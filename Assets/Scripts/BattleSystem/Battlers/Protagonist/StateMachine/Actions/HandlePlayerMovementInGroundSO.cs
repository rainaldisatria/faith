using AnthaGames.Assets.Scripts.BattleSystem.Battlers.Protagonist; 
using UnityEngine;

[CreateAssetMenu(fileName = "HandlePlayerMovementInGround", menuName = "State Machines/Actions/Handle Player Movement In Ground")]
public class HandlePlayerMovementInGroundSO : StateActionSO<HandlePlayerMovementInGroundAction>
{
    public float speed = 8f;
}

public class HandlePlayerMovementInGroundAction : StateAction
{ 
    private Protagonist _protagonist;
    private HandlePlayerMovementInGroundSO _originSO => (HandlePlayerMovementInGroundSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    { 
        this._protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnUpdate()
    {
        _protagonist.movementVector.x = _protagonist.movementInput.x * _originSO.speed;
        _protagonist.movementVector.z = _protagonist.movementInput.z * _originSO.speed;
    }
}
