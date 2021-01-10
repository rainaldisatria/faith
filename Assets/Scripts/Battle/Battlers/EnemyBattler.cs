using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBattler : Battler, ITargetable
{
    [SerializeField] private ManagerSO _targetManager;

    [HideInInspector] public NavMeshAgent NavMeshAgent; // get
    [HideInInspector] public Vector3 Home; // get 

    [SerializeField] private HealthbarEventChannelSO OnHitted;
    public Action OnDead;

    protected override void Awake()
    {
        base.Awake();

        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = Data.MoveSpeed;

        Home = this.transform.position;
    } 

    protected virtual void Update()
    {
        OnObjectOutsideScreenSpace();
        OnObjectWithinScreenSpace();
    }

    public override void TakeDamage(int damage, Transform damager)
    {
        base.TakeDamage(damage, damager);

        OnHitted.RaiseEvent(gameObject.GetInstanceID(), Head, Data);
    }

    protected override void Dead()
    { 
        OnDead?.Invoke();
        Destroy(this.gameObject, 0.1f);
    }

    public override void Attack()
    { 
        StartCoroutine("StartAttack");
    } 

    private IEnumerator StartAttack()
    {
        if (!isAttacking)
        {
            if (IsHitted)
                isAttacking = false;

            isAttacking = true;

            yield return new WaitForSeconds(Random.Range(1f, 1f));
            this.Animators.PlayAll((i) =>
                this.Animators[i].SetBool("isAttacking", true));

            yield return null; 

            this.Animators.PlayAll((i) =>
                this.Animators[i].SetBool("isAttacking", false));

            yield return new WaitForSeconds(Random.Range(0.3f, 1));

            isAttacking = false;
        }
    }

    public void OnObjectWithinScreenSpace()
    { 
        if (Utility.IsUnitWihthinScreenSpace(Camera.main.WorldToScreenPoint(Mid.position)))
        {
            ((TargetManager)(_targetManager.Manager)).AddTarget(Mid);
        }
    }

    public void OnObjectOutsideScreenSpace()
    {
        if (!Utility.IsUnitWihthinScreenSpace(Camera.main.WorldToScreenPoint(Mid.position)))
        {
            ((TargetManager)(_targetManager.Manager)).RemoveTarget(Mid);
        }
    }
}
