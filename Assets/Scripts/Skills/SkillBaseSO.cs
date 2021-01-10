using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBaseSO : ScriptableObject, ISkills
{
    [SerializeField] protected string SkillName;
    [SerializeField] protected string AnimationToPlay;
    [SerializeField] protected float TransitionDuration;
    [SerializeField] protected float Delay;
    [SerializeField] protected float Duration;

    /// <summary>
    /// Play skill animation then wait for delay.
    /// </summary>
    /// <param name="battler"></param>
    public virtual IEnumerator Execute(Battler battler)
    { 
        battler.GetComponent<Animator>().CrossFade(Animator.StringToHash(AnimationToPlay), TransitionDuration);
        yield return new WaitForSeconds(Delay);
    }

    protected virtual IEnumerator Done(Battler battler)
    { 
        yield return new WaitForSeconds(Duration);
        battler.IsUsingSkill = false;
    }
}
