using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBaseSO : ScriptableObject, ISkills
{
    [SerializeField] protected string SkillName;
    [SerializeField] protected string AnimationToPlay;
    [SerializeField] private float transitionDuration;
    [SerializeField] protected float Delay; 

    public virtual IEnumerator Execute(Battler battler)
    {
        battler.IsUsingSkill = true;
        battler.GetComponent<Animator>().CrossFade(Animator.StringToHash(SkillName), transitionDuration);
        yield return new WaitForSeconds(Delay);
    }
}
