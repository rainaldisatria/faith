using UnityEngine;

[CreateAssetMenu(fileName = "IsPlayerBetweenRadius", menuName = "State Machines/Conditions/Is Player Between Radius")]
public class PlayerBetweenRadiusConditionSO : StateConditionSO<BetweenRadiusCondition>
{
    public float Radius = 15;
}

public class BetweenRadiusCondition : Condition
{
    private GameObject _playerPos;
    private Transform _currentPos;
    private PlayerBetweenRadiusConditionSO _originSO => (PlayerBetweenRadiusConditionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player");
        _currentPos = stateMachine.transform;
    }

    protected override bool Statement()
    {
        if (Vector3.Distance(_currentPos.transform.position, _playerPos.transform.position) < _originSO.Radius)
        {
            return true;
        }

        return false;
    }
}
