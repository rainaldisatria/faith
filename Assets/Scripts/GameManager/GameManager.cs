using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Manager
{
    [SerializeField] private ManagerSO _sceneLoaderManagerSO;
    [SerializeField] private ManagerSO _audioManager;
    [SerializeField] private VoidEventChannelSO _onPlayerDeadSO;
    [SerializeField] private VoidEventChannelSO _exitGameSO;
    [SerializeField] private VoidEventChannelSO OnSceneLoaded;
    [SerializeField] private Image _image;

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

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
    float deltaTime = 0.0f;
    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 8 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
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
            StartCoroutine(((AudioManager)(_audioManager.Manager)).FadeInMusic(0.1f));
            isPlayerDead = true;
            _image.gameObject.SetActive(true);
            Time.timeScale = 0.3f;
            yield return new WaitForSecondsRealtime(4f);
            ((SceneLoaderManager)(_sceneLoaderManagerSO.Manager)).LoadScene("GameOver"); 
            Time.timeScale = 1f;
            _image.gameObject.SetActive(false);
        }
    }
    #endregion

    public void ExitGame()
    {
        Application.Quit();
    }
}
