using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneControl/Levels/Battle")]
public class BattleEventSO : LevelDataSO
{
    [SerializeField] private string BattleData;

    public override void Execute()
    {
        base.Execute();
        
    }
}
