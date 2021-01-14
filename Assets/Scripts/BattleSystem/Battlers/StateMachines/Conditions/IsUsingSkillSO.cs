using AnthaGames.Assets.Scripts.BattleSystem.Battlers; 
using UnityEngine;

[CreateAssetMenu(fileName = "Battler_IsUsingSkill", menuName = "State Machines/Conditions/Battler Is Using Skill")]
public class IsUsingSkillSO : StateConditionSO<IsUsingSkillCondition>
{

}

public class IsUsingSkillCondition : Condition
{
    private Battler _battler;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<Battler>();
    }

    protected override bool Statement()
    { 
        return _battler.IsUsingSkill;
    }
}
