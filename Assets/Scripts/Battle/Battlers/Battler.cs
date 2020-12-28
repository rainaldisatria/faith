using UnityEngine;

public abstract class Battler : MonoBehaviour, IDamageable
{
    [SerializeField] protected BattlerData Data;
    protected Animator[] _animators;

    [HideInInspector] public bool IsHitted;


    protected virtual void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
    }

    public virtual void TakeDamage(int damage)
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
}

