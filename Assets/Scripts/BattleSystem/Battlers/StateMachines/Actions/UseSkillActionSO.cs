using AnthaGames.Assets.Scripts.BattleSystem.Battlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "UseSkill", menuName = "State Machines/Actions/Use Skill")]
public class UseSkillActionSO : StateActionSO<UseSkillAction>
{
    
}

public class UseSkillAction : StateAction
{
    private Battler _battler;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<Battler>();
    }

    public override void OnStateEnter()
    {
        _battler.UseSkill();
    }

    public override void OnUpdate() { }
}
