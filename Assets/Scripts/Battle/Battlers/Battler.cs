using UnityEngine;
using UnityEngine.Events;

public abstract class Battler : MonoBehaviour, IDamageable, IDamageDealer
{
    [SerializeField] protected BattlerData Data;
    protected Animator[] _animators;
    protected Transform _head;

    [HideInInspector] public bool isAttacking;  
    [HideInInspector] public bool IsHitted; 
     
    private DamageDealer _damageDealer;
     
    protected virtual void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();

        _head = transform.Find("Head");
        if (_head == null)
            Debug.LogError("Battler has no head referenced");

        _damageDealer = new DamageDealer(GetComponentsInChildren<DamageDealerTrigger>());

        Data = Instantiate(Data);
    }

    public virtual void TakeDamage(int damage, Transform damager)
    { 
        IsHitted = true; 

        Data.HP -= damage;

        CheckCondition();
    }

    protected virtual void CheckCondition()
    {
        if(Data.HP <= 0)
        {
            OnDeath();
        }
    }

    protected abstract void OnDeath();

    public abstract void OnAttack();

    public void DealDamageStart(int damage)
    {
        _damageDealer.DealDamageStart(Data.Damage);
    }

    public void DealDamageEnded()
    {
        _damageDealer.DealDamageEnded();
    }
}

