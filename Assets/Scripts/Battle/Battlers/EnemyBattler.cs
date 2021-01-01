using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBattler : Battler
{
    [HideInInspector] public NavMeshAgent NavMeshAgent; // get
    [HideInInspector] public Vector3 Home; // get 

    [SerializeField] private HealthbarEventChannelSO OnHitted;

    protected override void Awake()
    {
        base.Awake();

        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = Data.MoveSpeed;

        Home = this.transform.position;
    }

    public override void TakeDamage(int damage, Transform damager)
    {
        base.TakeDamage(damage, damager);

        OnHitted.RaiseEvent(gameObject.GetInstanceID(), _head, Data);
    }

    protected override void Dead()
    { 
        Destroy(this.gameObject, 10);
    }

    public override void Attack()
    { 
        StartCoroutine("StartAttacking");
    } 

    private IEnumerator StartAttacking()
    {
        if (!isAttacking)
        {
            if (IsHitted)
                isAttacking = false;

            isAttacking = true;

            yield return new WaitForSeconds(Random.Range(0f, 0.7f));
            this._animators.PlayAll((i) =>
                this._animators[i].SetBool("isAttacking", true));

            yield return null; 

            this._animators.PlayAll((i) =>
                this._animators[i].SetBool("isAttacking", false));

            yield return new WaitForSeconds(Random.Range(0.3f, 1));

            isAttacking = false;
        }
    }
}
