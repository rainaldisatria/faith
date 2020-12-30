using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : Manager
{ 
    [SerializeField] private ManagerSO _screenEffectManagerSO;

    private AsyncOperation asyncLoad;

    public void ChangeScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));
    }

    #region Loading scene methods
    /// <summary>
    /// Load the scene asynchronously.
    /// </summary>
    /// <param name="name">Name of the scene.</param>
    /// <returns></returns>
    private IEnumerator LoadSceneAsync(string name)
    {
        ((ScreenEffectManager)(_screenEffectManagerSO.Manager)).FadeIn();

        asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }

        ((ScreenEffectManager)(_screenEffectManagerSO.Manager)).FadeOut();
    }
    #endregion
}
