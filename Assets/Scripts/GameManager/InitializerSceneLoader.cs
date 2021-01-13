using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializerSceneLoader : MonoBehaviour
{ 
    public const string InitializerSceneName = "InitializerScene";

    private void Awake()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == InitializerSceneName)  // Initializer scene is already loaded.{
            {
                return;
            } 
        }

        SceneManager.LoadScene(InitializerSceneName, LoadSceneMode.Additive);
        Destroy(this.gameObject);
    } 
}
