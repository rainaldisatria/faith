using AnthaGames.Assets.Scripts.BattleSystem.Battlers;
using AnthaGames.Assets.Scripts.BattleSystem.Battlers.Protagonist;
using AnthaGames.Assets.Scripts.SkillSystem.ScriptableObjects;
using DG.Tweening;
using System.Collections; 
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/DodgeSkill")]
public class DodgeSkill : SkillBaseSO
{
    [SerializeField] private float _speed; 

    private float startTime;

    public override IEnumerator Execute(Battler battler, Transform target)
    { 
        yield return base.Execute(battler, target);

        startTime = Time.time; 

        battler.StartCoroutine(StartDash(battler as Protagonist));
    }

    private IEnumerator StartDash(Protagonist battler)
    { 
        CharacterController cc = battler.GetComponent<CharacterController>();
        cc.detectCollisions = false;

        Vector3 direction = battler.movementInput; 
        if(direction == Vector3.zero)
        {
            direction = battler.transform.forward; 
        } 
        battler.transform.forward = direction; 


        while (startTime + Duration > Time.time)
        { 
            cc.Move(direction.normalized * _speed * Time.deltaTime);
            cc.Move(new Vector3(0, -10f * Time.deltaTime, 0));
            yield return null;
        }

        cc.detectCollisions = true;
        battler.StartCoroutine(Done(battler)); 
    }

    protected override IEnumerator Done(Battler battler)
    {
        yield return null;
        battler.IsUsingSkill = false; 
    }
}
