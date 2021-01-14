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
public class Wave
{
    public float delay;
    public List<GameObject> Troops; 
} 