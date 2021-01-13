using UnityEngine;
 
public abstract class LevelDataSO : ScriptableObject
{
    public string LevelName { get => _levelName; }

    [SerializeField] private string _levelName; 
    [SerializeField] private string _sceneName;

    public virtual void Execute(SceneLoaderManager sceneLoader)
    { 
        sceneLoader.LoadScene(_sceneName);
    }
}
