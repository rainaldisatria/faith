using UnityEngine;

public abstract class Battler : MonoBehaviour, IDamageable
{
    [SerializeField] private BattlerData _data;
    protected Animator[] _animators;

    [HideInInspector] public bool IsHitted;


    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
    }

    public virtual void TakeDamage(int damage)
    {
        IsHitted = true;

        _data.HP -= damage;

        this._animators.PlayAll(
            (i) => this._animators[i].Play("isHitted", -1, 0)
            ); 

        CheckCondition();
    }

    protected virtual void CheckCondition()
    {
        if(_data.HP <= 0)
        {
            OnDeath();
        }
    }

    protected abstract void OnDeath();
}

