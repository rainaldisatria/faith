using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    [SerializeField] private ManagerSO _sceneLoaderManagerSO;
    [SerializeField] private VoidEventChannelSO _onPlayerDeadSO;
    [SerializeField] private VoidEventChannelSO _exitGameSO;
    [SerializeField] private VoidEventChannelSO OnSceneLoaded;

    private void Start()
    { 
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    { 
        OnSceneLoaded.OnEventRaised += () => { isPlayerDead = false; };

        _onPlayerDeadSO.OnEventRaised += OnPlayerDead;
        _exitGameSO.OnEventRaised += ExitGame;
    }

    private void OnDisable()
    {
        _onPlayerDeadSO.OnEventRaised -= OnPlayerDead;
        _exitGameSO.OnEventRaised -= ExitGame;
    }

    #region OnPlayerDead
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
    #endregion

    public void ExitGame()
    {
        Application.Quit();
    }
}
