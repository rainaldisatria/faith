using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private StringEventChannelSO _loadScene;

    [SerializeField] private int needToKill;
    [SerializeField] private VoidEventChannelSO _enemyDead;

    private int killedEnemy;

    private void OnEnable()
    {
        //_enemyDead.OnEventRaised += EnemyDead;
    }

    private void OnDisable()
    {
        //_enemyDead.OnEventRaised -= EnemyDead;
    }

    private void EnemyDead()
    {
        killedEnemy++;

        if(needToKill == killedEnemy)
        {
            _loadScene.RaiseEvent("Menu");
        }
    }
}
