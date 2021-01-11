using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : Manager
{
    public const string InitializerScene = "InitializerScene";

    [SerializeField] private ManagerSO _screenEffectManagerSO;

    [Header("Event")]
    [SerializeField] private StringEventChannelSO _loadScene;

    private AsyncOperation asyncLoad;

    private void OnEnable()
    {
        _loadScene.OnEventRaised += LoadScene;
    }

    private void OnDisable()
    {
        _loadScene.OnEventRaised -= LoadScene;
    }

    public void LoadScene(string name)
    { 
        StartCoroutine(LoadSceneAsync(name));
    }

    #region Loading scene methods
    /// <summary>
    /// Load the scene asynchronously.
    /// </summary>
    /// <param name="name">Name of the scene.</param>
    /// <returns></returns>
    private IEnumerator LoadSceneAsync(string name, float fadeInDuration = 0.5f, float fadeOutDuration = 0.5f)
    {
        ((ScreenEffectManager)(_screenEffectManagerSO.Manager)).FadeOut(fadeInDuration); 

        yield return new WaitForSeconds(fadeInDuration);

        asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                UnloadScene(); 
                ((ScreenEffectManager)(_screenEffectManagerSO.Manager)).FadeIn(fadeOutDuration);
                asyncLoad.allowSceneActivation = true; 
            }

            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
    }

    private void UnloadScene()
    {
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene.name != InitializerScene)
            {
                SceneManager.UnloadScene(scene);
            }
        }
    }
    #endregion
}
