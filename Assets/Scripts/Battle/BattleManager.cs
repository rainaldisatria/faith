using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Manager
{
    [SerializeField] private ManagerSO _sceneLoaderManagerSO;
    public BattleData BattleData { get; private set; }

    public void SetBattleData(BattleData battleData)
    {
        BattleData = battleData;
    }

    public IEnumerator Spawn(Wave wave, Transform placeToSpawn, Action onDead)
    {
        yield return new WaitForSeconds(wave.delay); 
        for(int i = 0; i < wave.Troops.Count; i++)
        {
            GameObject obj = Instantiate(wave.Troops[i], placeToSpawn.position, placeToSpawn.rotation, placeToSpawn.parent);
            obj.GetComponent<EnemyBattler>().OnDead += onDead;
        }
    }

    public void Done()
    {
        StartCoroutine(LoadMainMenu());
    }

    private IEnumerator LoadMainMenu()
    {
        Debug.Log("Win");
        yield return new WaitForSeconds(3);
        ((SceneLoaderManager)(_sceneLoaderManagerSO.Manager)).LoadScene("MainMenu");
    }
}
