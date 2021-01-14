using AnthaGames.Assets.Scripts.BattleSystem.Battlers.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_SetChasing", menuName = "State Machines/Actions/Enemy_Set Chasing")]
public class BackToHome : StateActionSO<SetChasingToTrueAction>
{
    public StateAction.SpecificMoment moment;
    public bool value;
}

public class SetChasingToTrueAction : StateAction
{
    private EnemyBattler _enemyBattler;
    private BackToHome _originSO => (BackToHome)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _enemyBattler = stateMachine.GetComponent<EnemyBattler>();
    } 

    public override void OnUpdate() { }
}
