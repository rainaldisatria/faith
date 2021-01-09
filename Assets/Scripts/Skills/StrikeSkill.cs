using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Strike Skill")]
public class StrikeSkill : SkillBaseSO
{
    public override IEnumerator Execute(Battler battler)
    {
        yield return base.Execute(battler);
        battler.GetComponent<Experiment>().Warp(); 
        battler.StartCoroutine(Done(battler));
    }
}
