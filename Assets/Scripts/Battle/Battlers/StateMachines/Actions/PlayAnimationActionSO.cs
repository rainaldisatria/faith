using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PlayAnimation", menuName = "State Machines/Actions/Play Animation")]
public class PlayAnimationActionSO : StateActionSO
{
    public string animationStateName;
    public float transitionDuration = 0.25f;
    protected override StateAction CreateAction() => new PlayAnimationAction(Animator.StringToHash(animationStateName));
}

public class PlayAnimationAction : StateAction
{
    private Animator[] _animators;
    private PlayAnimationActionSO _baseOrigin => (PlayAnimationActionSO)base.OriginSO;
    private int _parameterHash;

    public PlayAnimationAction(int hash)
    {
        _parameterHash = hash;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _animators = stateMachine.GetComponentsInChildren<Animator>();
    }

    public override void OnStateEnter()
    {
        _animators.PlayAll(
            (i) => _animators[i].CrossFade(_parameterHash, _baseOrigin.transitionDuration, -1, 0));
    }

    public override void OnUpdate()
    {

    }
}
