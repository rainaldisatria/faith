using System.Collections; 
using UnityEngine;

public class Skeleton : EnemyBattler
{ 
    #region Behaviour 
    public override void Attack()
    {
        StartCoroutine("StartAttack");
    }

    protected override void Dead()
    {
        base.Dead();
        OnDead?.Invoke();
        ((TargetManager)(_targetManager.Manager)).RemoveTarget(Mid);
        Destroy(this);
        Destroy(GetComponent<Collider>());
        Destroy(NavMeshAgent);
        Destroy(this.gameObject, 5f);
    }

    public override void UseSkill()
    {
        IsUsingSkill = true; 
        int skillDecisionID = Random.Range(0, Data.Skills.Count - 1);
        StartCoroutine(Data.Skills[skillDecisionID].Execute(this, Target));
    }

    public override void TakeDamage(int damage, Transform damager)
    {
        base.TakeDamage(damage, damager);
        StopCoroutine("StartAttack");
        IsAttacking = false;
    }

    private IEnumerator StartAttack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true; 

            yield return new WaitForSeconds(Random.Range(0.1f, 1f));  

            this.Animators.PlayAll((i) =>
                this.Animators[i].CrossFade("Attack1", 0.25f, -1, 0));

            yield return new WaitForSeconds(Random.Range(0.3f, 1));

            IsAttacking = false;
        }
    }
    #endregion
}
