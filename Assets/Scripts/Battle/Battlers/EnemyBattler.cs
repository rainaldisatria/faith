using System;
using System.Collections; 
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBattler : Battler, ITargetable
{
    [SerializeField] private ManagerSO _targetManager;

    #region State machine fields
    [HideInInspector] public NavMeshAgent NavMeshAgent;
    [HideInInspector] public Vector3 Home;
    #endregion

    #region Events
    [SerializeField] private HealthbarEventChannelSO OnHitted;
    public Action OnDead;
    #endregion

    /// <summary>
    /// Initialization.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = Data.MoveSpeed;

        Home = this.transform.position;

        Target = GameObject.FindWithTag("Player").transform;
    } 

    protected virtual void Update()
    {
        OnObjectOutsideScreenSpace();
        OnObjectWithinScreenSpace();
    }

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
        Skill = Data.Skills[skillDecisionID];

        base.UseSkill();
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
    #endregion

    #region IDamageable
    public override void TakeDamage(int damage, Transform damager)
    {
        base.TakeDamage(damage, damager);

        OnHitted.RaiseEvent(gameObject.GetInstanceID(), Head, Data);
    }
    #endregion

    #region ITargetable
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
    #endregion
}
