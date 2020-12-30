using UnityEngine;

public abstract class LevelEvent : ScriptableObject
{  
    public string SceneName;

    [Header("Scene Loader Manager")]
    [SerializeField] private ManagerSO _sceneLoaderManagerSO;

    public virtual void Execute()
    {
        //((SceneLoaderManager)_sceneLoaderManagerSO.Manager).ChangeScene(SceneName);
    }
}
