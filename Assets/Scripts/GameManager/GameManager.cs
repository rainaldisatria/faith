using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    [SerializeField] private ManagerSO _sceneLoaderManagerSO;
    [SerializeField] private VoidEventChannelSO _onPlayerDeadSO;

    private void OnEnable()
    {
        _onPlayerDeadSO.OnEventRaised += OnPlayerDead;
    }

    private void OnDisable()
    {
        _onPlayerDeadSO.OnEventRaised -= OnPlayerDead;
    }

    bool isPlayerDead;
    public void OnPlayerDead()
    {
        StartCoroutine(PlayerDead());
    }

    private IEnumerator PlayerDead()
    {
        if (!isPlayerDead)
        { 
            isPlayerDead = true;
            Time.timeScale = 0.3f;
            yield return new WaitForSecondsRealtime(4f);
            ((SceneLoaderManager)(_sceneLoaderManagerSO.Manager)).LoadScene("GameOver");
            Time.timeScale = 1f;
        }
    }
}
