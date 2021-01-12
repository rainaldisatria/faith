using System.Collections; 
using UnityEngine;

public class Skeleton : EnemyBattler
{ 
    #region Behaviour 
    public override void Attack()
    {
        StartCoroutine("StartAttack");
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
