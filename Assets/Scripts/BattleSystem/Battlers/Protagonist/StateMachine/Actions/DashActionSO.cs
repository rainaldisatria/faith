using AnthaGames.Assets.Scripts.BattleSystem.Battlers;
using AnthaGames.Assets.Scripts.BattleSystem.Battlers.Protagonist;
using DG.Tweening;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "State Machines/Actions/Dash")]
public class DashActionSO : StateActionSO<DashAction>
{
    public float dashSpeed;
    public float dashDuration;
    public ManagerSO _targetManagerSO;
}

public class DashAction : StateAction
{
    private Battler _battler;
    private CharacterController _cc;
    private TargetManager _targetManager;
    private Transform target;

    private DashActionSO _originSO => (DashActionSO)base.OriginSO;

    private float startTime;

    public override void Awake(StateMachine stateMachine)
    {
        this._battler = stateMachine.GetComponent<Battler>();
        _cc = stateMachine.GetComponent<CharacterController>();
    }

    public override void OnStateEnter()
    { 
        _targetManager = ((TargetManager)((_originSO._targetManagerSO.Manager)));
        target = _targetManager.Target;

        startTime = Time.time;

        if (_battler is Protagonist)
        {
            if (startTime + _originSO.dashDuration > Time.time)
            {
                if (target == null)
                {
                    _battler.StartCoroutine(StartDash(false));
                }
                else
                {
                    _battler.transform.DOLookAt(target.transform.position, 0.1f);
                    _battler.StartCoroutine(StartDash(true));
                }
            }
        }
    }

    private IEnumerator StartDash(bool withTarget)
    {
        while(startTime + _originSO.dashDuration >= Time.time)
        {
            if(withTarget)
                _cc.Move((_battler.transform.forward - target.transform.forward) * Time.deltaTime * _originSO.dashSpeed);
            else
                _cc.Move(_battler.transform.forward * Time.deltaTime * _originSO.dashSpeed);
            yield return null;
        }
    }

    public override void OnUpdate()
    {
         
    }
}
