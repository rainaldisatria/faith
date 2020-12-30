using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Battle Data", menuName = "BattleSystem/BattleData")]
public class BattleData : ScriptableObject
{
    public List<GameObject> Troops;
    public GameObject BattleMap;
}
