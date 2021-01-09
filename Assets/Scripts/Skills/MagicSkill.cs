using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Magic Skill")]
public class MagicSkill : DamageSkill
{
    [SerializeField] private GameObject effect;

    public override IEnumerator Execute(Battler battler)
    {
        yield return base.Execute(battler);
        GameObject obj = Instantiate(effect, battler.transform.position, battler.transform.rotation);
        obj.GetComponent<DamageDealerTrigger>().SetUserTag(battler.tag);
        obj.GetComponent<DamageDealerTrigger>().Enable(Damage);

        battler.StartCoroutine(Done(battler));
    }
}
