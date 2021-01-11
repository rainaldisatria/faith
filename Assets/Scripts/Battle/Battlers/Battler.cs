﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Battler : MonoBehaviour, IDamageable, IDamageDealer
{
    [SerializeField] protected BattlerData Data;
    protected Animator[] Animators;
    protected Transform Head;
    protected Transform Mid;

    [HideInInspector] public bool isAttacking;  
    [HideInInspector] public bool IsHitted;
    [HideInInspector] public bool IsDead;
    [HideInInspector] public bool IsUsingSkill;
     
    private DamageDealerController _damageDealer;
    
    protected ISkill Skill;
    protected Transform target;
     
    // Inisialisasi
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

    public virtual void TakeDamage(int damage, Transform damager)
    {
        StartCoroutine(SetIsHittedToTrue());

        DealDamageEnded();

        Data.HP -= damage; 

        CheckCondition();
    }

    private IEnumerator SetIsHittedToTrue()
    {
        IsHitted = true;
        yield return null;
        IsHitted = false;
    }

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

    public abstract void Attack();

    public virtual void UseSkill()
    {
        StartCoroutine(Skill.Execute(this, target)); 
    }

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

