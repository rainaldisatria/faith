using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Battler : MonoBehaviour, IDamageable, IDamageDealer
{
    #region Fields
    [SerializeField] protected BattlerData Data;
    protected Animator[] Animators;
    protected ISkill Skill;
    protected Transform Target;

    protected Transform Head { get; private set; }
    protected Transform Mid { get; private set; }
    private DamageDealerController _damageDealer;
    #endregion

    #region State machine fields
    [HideInInspector] public bool IsAttacking;  
    [HideInInspector] public bool IsHitted;
    [HideInInspector] public bool IsDead;
    [HideInInspector] public bool IsUsingSkill;
    #endregion 

    // Initialization
    protected virtual void Awake()
    {
        Animators = GetComponentsInChildren<Animator>();

        Head = transform.Find("Head");
        if (Head == null)
            Debug.LogError("Battler has no head referenced");

        Mid = transform.Find("Mid");
        if (Mid == null)
            Debug.LogError("Battler has no mid referenced");

        _damageDealer = new DamageDealerController(GetComponentsInChildren<DamageDealerTrigger>());

        Data = Instantiate(Data);
    }

    #region Behaviour
    protected virtual void CheckCondition()
    {
        if (Data.HP <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        IsDead = true;
    }

    public virtual void Attack()
    {
        IsAttacking = true;
    }

    public virtual void UseSkill()
    { 
        StartCoroutine(Skill.Execute(this, Target));
    }

    private IEnumerator SetIsHittedToTrue()
    {
        IsHitted = true;
        yield return null;
        IsHitted = false;
    }
    #endregion

    #region IDamageable
    public virtual void TakeDamage(int damage, Transform damager)
    {
        StartCoroutine(SetIsHittedToTrue());

        DealDamageEnded();

        Data.HP -= damage;

        CheckCondition();
    }
    #endregion

    #region IDamageDealer
    public void DealDamageStart()
    {
        _damageDealer.Start(Data.Damage);
    }

    public void DealDamageEnded()
    {
        _damageDealer.End();
    }
    #endregion
}

