using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Manager
{
    private BattleData _battleData;

    public void PlayBattleData(BattleData battleData)
    {
        _battleData = battleData;
    }
}
