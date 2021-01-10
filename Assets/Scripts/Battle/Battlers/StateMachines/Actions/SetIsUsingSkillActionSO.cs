using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "SetIsUsingSkill", menuName = "State Machines/Actions/SetIsUsingSkill_")]
public class SetIsUsingSkillActionSO : StateActionSO<SetIsUsingSkillAction>
{
    public bool IsUsingSkill;
}

public class SetIsUsingSkillAction : StateAction
{
    private Battler _battler;
    private SetIsUsingSkillActionSO _originSO => (SetIsUsingSkillActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<Battler>();
    }

    public override void OnStateEnter()
    {
        _battler.IsUsingSkill = _originSO.IsUsingSkill;
    }

    public override void OnUpdate() { }
}
