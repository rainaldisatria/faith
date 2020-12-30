using UnityEngine;

[CreateAssetMenu(menuName = "LevelSystem/BattleEvent")]
public class BattleEvent : LevelEvent
{ 
    public BattleData BattleData { get => _battleData; }

    [Header("Battle Event")]
    [SerializeField] private ManagerSO _battleManagerSO;
    [SerializeField] private BattleData _battleData;

    //private BattleManager _battleManager;

    private void Awake()
    {
        //_battleManager = _battleManagerSO.Manager as BattleManager;
    }

    public override void Execute()
    {
        //base.Execute(); 
    }
}
