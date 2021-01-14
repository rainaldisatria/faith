using AnthaGames.Assets.Scripts.BattleSystem.Battlers; 
using UnityEngine;

[CreateAssetMenu(fileName = "Battler_IsDead", menuName = "State Machines/Conditions/Battler Is Dead")]
public class IsDeadConditionSO : StateConditionSO<IsDeadCondition>
{

}

public class IsDeadCondition : Condition
{
    private Battler _battler;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<Battler>();
    }

    protected override bool Statement()
    {
        if (_battler.IsDead)
        {
            return true;
        }

        return false;
    }
}
