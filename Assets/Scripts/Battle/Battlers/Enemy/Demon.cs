using DG.Tweening;
using System.Collections; 
using UnityEngine;

public class Demon : EnemyBattler
{
    [SerializeField] private GameObject _effect;

    #region Behaviour
    public override void Attack()
    {
        StartCoroutine("StartAttack");
    } 

    protected override IEnumerator StartAttack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;

            transform.DOLookAt(Target.transform.position, 0.25f, AxisConstraint.Y);

            yield return new WaitForSeconds(Random.Range(0f, 0.1f));

            this.Animators.PlayAll((i) =>
                this.Animators[i].CrossFade("Attack1", 0.25f, -1, 0));

            StartCoroutine(PlayEffect());

            yield return new WaitForSeconds(Random.Range(4f, 5));

            IsAttacking = false;
        }
    }

    private IEnumerator PlayEffect()
    {
        yield return new WaitForSeconds(3.5f); 
        GameObject effect = Instantiate(_effect);
        effect.transform.position = transform.position;
        Destroy(effect, 1);
    }
    #endregion
}
