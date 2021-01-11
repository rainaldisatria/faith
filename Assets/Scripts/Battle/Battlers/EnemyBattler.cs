using System;
using System.Collections; 
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

        target = GameObject.FindWithTag("Player").transform;
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
        base.Dead();
        OnDead?.Invoke();
        ((TargetManager)(_targetManager.Manager)).RemoveTarget(Mid);
        Destroy(this); 
        Destroy(GetComponent<Collider>()); 
        Destroy(NavMeshAgent); 
        Destroy(this.gameObject, 5f); 
    }

    public override void Attack()
    { 
        StartCoroutine("StartAttack");
    } 

    private IEnumerator StartAttack()
    {
        if (!isAttacking)
        {
            if (IsHitted || IsDead)
            {
                isAttacking = false;
                yield break;
            }

            isAttacking = true;

            yield return new WaitForSeconds(Random.Range(1f, 1f));

            if (IsHitted || IsDead)
            {
                isAttacking = false;
                yield break;
            }
                

            this.Animators.PlayAll((i) =>
                this.Animators[i].CrossFade("Attack1", 0.25f, -1, 0)); 

            yield return new WaitForSeconds(Random.Range(0.3f, 1));

            isAttacking = false;
        }
    }

    public override void UseSkill()
    {
        IsUsingSkill = true;

        int skillDecisionID = Random.Range(0, Data.Skills.Count - 1); 
        Skill = Data.Skills[skillDecisionID]; 

        base.UseSkill();
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
