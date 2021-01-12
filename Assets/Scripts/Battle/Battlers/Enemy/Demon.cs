using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : EnemyBattler
{
    public override void Attack()
    {
        StartCoroutine("StartAttack");
    }

    private IEnumerator StartAttack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;

            yield return new WaitForSeconds(Random.Range(0f, 0.1f));

            this.Animators.PlayAll((i) =>
                this.Animators[i].CrossFade("Attack1", 0.25f, -1, 0));

            yield return new WaitForSeconds(Random.Range(4f, 5));

            IsAttacking = false;
        }
    }
}
