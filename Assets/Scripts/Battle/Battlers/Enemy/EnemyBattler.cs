using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public abstract class EnemyBattler : Battler, ITargetable
{
    #region Depedency
    [SerializeField] protected ManagerSO _targetManager;
    #endregion

    #region State machine fields
    [HideInInspector] public NavMeshAgent NavMeshAgent;
    [HideInInspector] public Vector3 HomeCoordinate;
    #endregion

    #region Events
    public HealthbarEventChannelSO OnHitted;
    public Action OnDead;
    #endregion 

    #region Behaviour
    // Initialization. 
    protected override void Awake()
    {
        base.Awake();

        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = Data.MoveSpeed;

        HomeCoordinate = this.transform.position;

        Target = GameObject.FindWithTag("Player").transform;
    } 

    protected virtual void Update()
    {
        if (!IsDead)
        {
            OnObjectOutsideScreenSpace();
            OnObjectWithinScreenSpace();
        }
    }

    protected override void Dead()
    {
        IsDead = true;
        StopCoroutine("StartAttack");
        base.Dead();
        OnDead?.Invoke();
        ((TargetManager)(_targetManager.Manager)).RemoveTarget(Mid);
        Destroy(GetComponent<Collider>());
        Destroy(NavMeshAgent);
        Destroy(this.gameObject, 5f);
    }

    protected abstract IEnumerator StartAttack();

    public override void UseSkill()
    {
        if(Data.Skills.Count > 0)
        {
            IsUsingSkill = true;
            int skillDecisionID = Random.Range(0, Data.Skills.Count - 1);
            StartCoroutine(Data.Skills[skillDecisionID].Execute(this, Target));
        }
    }
    #endregion

    #region IDamageable
    public override void TakeDamage(int damage, Transform damager)
    {
        OnHitted.RaiseEvent(gameObject.GetInstanceID(), Head, Data);
        base.TakeDamage(damage, damager);
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
