using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BattleTrigger : MonoBehaviour
{
    [SerializeField] private ManagerSO _battleManagerSO;
    [SerializeField] private BattleData _battleData;

    private BattleManager _battleManager;
    private bool ableToSpawn = true;

    private int _waveCounter;
    private int _totalEnemy;
    private int _killedEnemy;

    private void Start()
    {
        _battleManager = ((BattleManager)(_battleManagerSO.Manager));
        if(_battleManager.BattleData != null)
        {
            _battleData = _battleManager.BattleData;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (ableToSpawn)
        {
            ableToSpawn = false;
            _killedEnemy = 0;
            _totalEnemy = _battleData.Waves[_waveCounter].Troops.Count;

            StartCoroutine(
                _battleManager.Spawn(_battleData.Waves[_waveCounter], 
                transform,
                OnDead
                ));
        }
    }

    private void OnDead()
    { 
        _killedEnemy++;

        if (_killedEnemy >= _totalEnemy)
        {
            _waveCounter++;

            if (_waveCounter < _battleData.Waves.Count)
            {
                ableToSpawn = true;
            } 
            else
            {
                _battleManager.Done();
            }
        }
    }
}
