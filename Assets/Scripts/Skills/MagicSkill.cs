using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Magic Skill")]
public class MagicSkill : SkillBaseSO
{
    [SerializeField] private GameObject effect;

    public override IEnumerator Execute(Battler battler)
    {
        yield return base.Execute(battler);
        Instantiate(effect, battler.transform); 

        battler.StartCoroutine(Done(battler));
    }
}
