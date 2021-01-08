using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBaseSO : ScriptableObject, ISkills
{
    [SerializeField] protected string SkillName;
    [SerializeField] protected string AnimationToPlay;
    [SerializeField] private float transitionDuration;
    [SerializeField] protected float Delay;
    [SerializeField] protected float Duration;

    public virtual IEnumerator Execute(Battler battler)
    {
        battler.IsUsingSkill = true;
        battler.GetComponent<Animator>().CrossFade(Animator.StringToHash(AnimationToPlay), transitionDuration);
        yield return new WaitForSeconds(Delay);
    }

    protected IEnumerator Done(Battler battler)
    { 
        yield return new WaitForSeconds(Duration);
        battler.IsUsingSkill = false;
    }
}
