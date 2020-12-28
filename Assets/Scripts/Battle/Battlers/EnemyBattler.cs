using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBattler : Battler
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    public bool isChasing = false;
    private Vector3 firstLocation;

    private GameObject player;

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();

        firstLocation = this.transform.position;
    }

    private void Update()
    {
        if (isChasing)
        {
            Chase(player.transform.position);
        }
        else
        {
            Chase(firstLocation);
        }
    }

    protected override void OnDeath()
    { 
    }

    private void Chase(Vector3 target)
    {
        _navMeshAgent.SetDestination(target);
    }
}
