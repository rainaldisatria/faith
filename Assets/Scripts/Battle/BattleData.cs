using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/BattleData")]
public class BattleData : ScriptableObject
{
    public List<Wave> Waves;
}
 
[Serializable]
public class WaveData
{
    public GameObject EnemyPrefab { get => _enemyPrefab; }
    public int Quantity { get => _quantity; }

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _quantity;
}

[Serializable]
public class Wave
{
    public List<WaveData> WaveData;
}
