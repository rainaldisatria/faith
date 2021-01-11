using UnityEngine;

[CreateAssetMenu(fileName = "IsRandomDecisionMet", menuName = "State Machines/Conditions/Is Random Decision Met")]
public class IsRandomDecisionMetConditionSO : StateConditionSO<IsRandomDecisionMetCondition>
{
    public int FavourableOutcome;
    public int NumberOfOutcome;
}

public class IsRandomDecisionMetCondition : Condition
{ 
    private IsRandomDecisionMetConditionSO _originSO => (IsRandomDecisionMetConditionSO)base.OriginSO;
    private bool _statement;

    public override void OnStateEnter()
    {
        int probability = Random.Range(_originSO.FavourableOutcome, _originSO.NumberOfOutcome);

        if (probability <= _originSO.FavourableOutcome)
            _statement = true; 
    }

    protected override bool Statement()
    {
        return _statement;
    }
}