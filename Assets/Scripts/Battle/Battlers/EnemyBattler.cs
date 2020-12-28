using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBattler : Battler
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    public bool isChasing = false;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
    } 

    protected override void OnDeath()
    {
        Destroy(this.gameObject);   
    }

    private void Chase(Vector3 target)
    {
        _navMeshAgent.SetDestination(target);
    }
}
