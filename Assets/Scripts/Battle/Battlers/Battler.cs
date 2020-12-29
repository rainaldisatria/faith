using UnityEngine;
using UnityEngine.Events;

public abstract class Battler : MonoBehaviour, IDamageable, IDamageDealer
{
    [SerializeField] protected BattlerData Data;
    protected Animator[] _animators;


    [HideInInspector] public bool isAttacking; 

    // Fields for SM.
    [HideInInspector] public bool IsHitted; 

    // DI
    public DamageDealer _damageDealer;


    protected virtual void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();

        _damageDealer = new DamageDealer(GetComponentsInChildren<DamageDealerTrigger>());

        Data = Instantiate(Data);
    }

    public virtual void TakeDamage(int damage, Transform damager)
    {
        IsHitted = true; 

        Data.HP -= damage;

        CheckCondition();
    }

    public abstract void OnAttack();

    protected virtual void CheckCondition()
    {
        if(Data.HP <= 0)
        {
            OnDeath();
        }
    }

    protected abstract void OnDeath();

    public void DealDamageStart(int damage)
    {
        _damageDealer.DealDamageStart(Data.Damage);
    }

    public void DealDamageEnded()
    {
        _damageDealer.DealDamageEnded();
    }
}

