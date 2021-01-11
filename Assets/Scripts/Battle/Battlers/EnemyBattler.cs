using System;
using System.Collections; 
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public abstract class EnemyBattler : Battler, ITargetable
{
    #region Depedency
    [SerializeField] private ManagerSO _targetManager;
    #endregion

    #region State machine fields
    [HideInInspector] public NavMeshAgent NavMeshAgent;
    [HideInInspector] public Vector3 HomeCoordinate;
    #endregion

    #region Events
    public HealthbarEventChannelSO OnHitted;
    public Action OnDead;
    #endregion
     
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
        OnObjectOutsideScreenSpace();
        OnObjectWithinScreenSpace();
    }

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
