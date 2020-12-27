using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeElapsed", menuName = "State Machines/Conditions/Time Elapsed")]
public class IsTimeElapsedConditionSO : StateConditionSO<IsTimeElapsedCondition>
{
    public float timerLength = .5f;
}

public class IsTimeElapsedCondition : Condition
{
    private float startTime;
    private IsTimeElapsedConditionSO _originSO => (IsTimeElapsedConditionSO)base.OriginSO;

    public override void OnStateEnter()
    {
        startTime = Time.time;
    }

    protected override bool Statement()
    {
        return Time.time > startTime + _originSO.timerLength;
    }
}