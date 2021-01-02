using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneControl/Levels/Battle")]
public class BattleEventSO : LevelDataSO
{
    [Header("Battle Event Data")]
    [SerializeField] private BattleData BattleData;
    [SerializeField] private ManagerSO _battleManagerSO;

    public override void Execute(SceneLoaderManager sceneLoader)
    {
        base.Execute(sceneLoader);
        ((BattleManager)(_battleManagerSO.Manager)).SetBattleData(BattleData);
    }
}
