using UnityEngine;

[CreateAssetMenu(fileName = "IsPlayerBetweenRadius", menuName = "State Machines/Conditions/Is Player Between Radius")]
public class PlayerBetweenRadiusConditionSO : StateConditionSO<BetweenRadiusCondition>
{
    public float Radius = 2;
}

public class BetweenRadiusCondition : Condition
{
    private GameObject _playerPos;
    private Vector3 _currentPos;
    private PlayerBetweenRadiusConditionSO _originSO => (PlayerBetweenRadiusConditionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player");
        _currentPos = stateMachine.transform.position;
    }

    protected override bool Statement()
    {
        if (Vector3.Distance(_currentPos, _playerPos.transform.position) < _originSO.Radius)
        {
            return true;
        }

        return false;
    }
}
