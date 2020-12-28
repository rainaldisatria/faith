using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Battler : MonoBehaviour, IDamageable
{
    [SerializeField] private BattlerData _data;
    protected Animator[] _animators;

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log("Damaged");

        _data.HP -= damage;

        this._animators.PlayAll(
            (i) => this._animators[i].SetBool("isHitted", true)
            );

        this._animators.PlayAll(
            (i) => this._animators[i].SetBool("isHitted", false)
            );

        CheckCondition();
    }

    public virtual void CheckCondition()
    {
        if(_data.HP <= 0)
        {
            OnDeath();
        }
    }

    public abstract void OnDeath();
}

