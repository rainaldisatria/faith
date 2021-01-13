﻿using DG.Tweening;
using System.Collections; 
using UnityEngine;

public class Skeleton : EnemyBattler
{  
    #region Behaviour 
    public override void Attack()
    {
        StartCoroutine("StartAttack");
    }

    protected override  IEnumerator StartAttack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;

            StartCoroutine(LookAtPlayer());

            yield return new WaitForSeconds(Random.Range(0.1f, 1f));  

            this.Animators.PlayAll((i) =>
                this.Animators[i].CrossFade("Attack1", 0.25f, -1, 0));

            yield return new WaitForSeconds(Random.Range(0.8f, 1));

            IsAttacking = false;
        }
    } 

    private IEnumerator LookAtPlayer()
    {
        while (IsAttacking)
        {
            transform.LookAt(Target);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            yield return null;
        }
    }
    #endregion

    #region IDamageable
    public override void TakeDamage(int damage, Transform damager)
    {
        base.TakeDamage(damage, damager);

        IsAttacking = false;
        StopCoroutine("StartAttack");
        DealDamageEnded();

        transform.DOMove(transform.position + damager.root.forward * 2.1f, .5f);
    }
    #endregion
}
