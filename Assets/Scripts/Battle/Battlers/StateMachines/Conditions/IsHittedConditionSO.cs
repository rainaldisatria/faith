using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battler_IsHitted", menuName = "State Machines/Conditions/Battler Is Hitted")]
public class IsHittedConditionSO : StateConditionSO<IsHittedCondition>
{

}

public class IsHittedCondition : Condition
{
    private Battler _battler;

    public override void Awake(StateMachine stateMachine)
    {
        _battler = stateMachine.GetComponent<Battler>();
    }

    protected override bool Statement()
    {
        if (_battler.IsHitted)
        {
            Debug.Log("Is hitted");
            _battler.IsHitted = false;
            return true;
        }

        return false;
    }
}
