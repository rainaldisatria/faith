using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Strike Skill")]
public class StrikeSkillSO : SkillBaseSO
{
    public override IEnumerator Execute(Battler battler)
    {
        yield return base.Execute(battler);
        battler.GetComponent<Experiment>().Warp();
        yield return null;
    }
}
