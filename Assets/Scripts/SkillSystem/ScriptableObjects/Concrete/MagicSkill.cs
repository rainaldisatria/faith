using AnthaGames.Assets.Scripts.BattleSystem.Battlers;
using AnthaGames.Assets.Scripts.SkillSystem.ScriptableObjects.Abstract;
using System.Collections; 
using UnityEngine;

namespace AnthaGames.Assets.Scripts.SkillSystem.ScriptableObjects.Concrete
{
    [CreateAssetMenu(menuName = "Skills/Magic Skill")]
    public class MagicSkill : DamageSkill
    {
        [SerializeField] private GameObject effect;

        public override IEnumerator Execute(Battler battler, Transform target)
        {
            battler.transform.LookAt(target);
            battler.transform.eulerAngles = new Vector3(0, battler.transform.eulerAngles.y, 0);

            yield return base.Execute(battler, target);

            if (target == null)
            {
                target = battler.transform;
            }

            battler.transform.LookAt(target);
            GameObject obj = Instantiate(effect, battler.transform.position, battler.transform.rotation);
            obj.GetComponent<DamageDealerTrigger>().SetUserTag(battler.tag);
            obj.GetComponent<DamageDealerTrigger>().Enable(Damage);

            yield return null;
            battler.transform.eulerAngles = new Vector3(0, battler.transform.eulerAngles.y, 0);

            battler.StartCoroutine(Done(battler));
        }
    }

}