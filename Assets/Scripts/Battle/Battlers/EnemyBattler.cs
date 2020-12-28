﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBattler : Battler
{
    [HideInInspector] public NavMeshAgent NavMeshAgent; // get
    [HideInInspector] public Vector3 Home; // get

    private bool isAttacking;

    protected override void Awake()
    {
        base.Awake();

        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = Data.MoveSpeed;

        Home = this.transform.position;
    } 

    protected override void OnDeath()
    { 

    }

    public override void OnAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;

            yield return new WaitForSeconds(Random.Range(1.5f, 5));
            Debug.Log("Attacking");

            isAttacking = false;
        }
    }
}
