using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "State Machines/Actions/Dash")]
public class DashActionSO : StateActionSO<DashAction>
{
    public float dashSpeed;
    public float dashDuration;
}

public class DashAction : StateAction
{
    private Battler _battler;
    private CharacterController _cc;

    private DashActionSO _originSO => (DashActionSO)base.OriginSO;

    private float startTime;

    public override void Awake(StateMachine stateMachine)
    {
        this._battler = stateMachine.GetComponent<Battler>();
        _cc = stateMachine.GetComponent<CharacterController>();
    }

    public override void OnStateEnter()
    {
        startTime = Time.time;
    }

    public override void OnUpdate()
    {
        if(_battler is Protagonist)
        {
            if (startTime + _originSO.dashDuration > Time.time)
            {
                _cc.Move(-_battler.transform.forward * Time.deltaTime * _originSO.dashSpeed);
            }
        }
        else
        {

        }
    }
}
