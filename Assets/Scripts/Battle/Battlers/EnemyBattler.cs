using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBattler : Battler
{
    [SerializeField] public NavMeshAgent _navMeshAgent; // get
    [SerializeField] public Vector3 Home; // get

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>(); 
        _navMeshAgent = GetComponent<NavMeshAgent>();

        Home = this.transform.position;
    } 

    protected override void OnDeath()
    { 

    }
}
