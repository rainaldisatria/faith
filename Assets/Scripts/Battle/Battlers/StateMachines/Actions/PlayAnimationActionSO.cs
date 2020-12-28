using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PlayAnimation", menuName = "State Machines/Actions/Play Animation")]
public class PlayAnimationActionSO : StateActionSO<PlayAnimationAction>
{
    public string animationStateName;
}

public class PlayAnimationAction : StateAction
{
    private Animator[] _animators;
    private PlayAnimationActionSO _baseOrigin => (PlayAnimationActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _animators = stateMachine.GetComponentsInChildren<Animator>();
    }

    public override void OnStateEnter()
    {
        _animators.PlayAll(
            (i) => _animators[i].Play(this._baseOrigin.animationStateName, -1, 0));
    }

    public override void OnUpdate()
    {

    }
}
