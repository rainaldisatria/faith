using AnthaGames.Assets.Scripts.BattleSystem.Battlers.Protagonist; 
using UnityEngine;

[CreateAssetMenu(fileName = "HandleGravityInGround", menuName = "State Machines/Actions/Handle Gravity In Ground")]
public class HandleGravityInGroundSO : StateActionSO<HandleGravityInGroundAction>
{
    public float pullForce = -9.8f;
}

public class HandleGravityInGroundAction : StateAction
{
    private Protagonist _protagonist;
    private HandleGravityInGroundSO _originSO => (HandleGravityInGroundSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnUpdate()
    {
        _protagonist.movementVector.y = _originSO.pullForce;
    }
}
