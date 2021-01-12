using DG.Tweening;
using System.Collections; 
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

            transform.DOLookAt(Target.transform.position, 0.25f, AxisConstraint.Y);

            yield return new WaitForSeconds(Random.Range(0f, 0.1f));

            int decision = Random.Range(0, 2); 

            switch (decision)
            {
                case 0:
                    IsUsingSkill = true;
                    break;
                case 1:
                    this.Animators.PlayAll((i) =>
                    this.Animators[i].CrossFade("Attack1", 0.25f, -1, 0)); 
                    yield return new WaitForSeconds(Random.Range(4f, 5));
                    break;
            }

            IsAttacking = false;
        }
    }
}
