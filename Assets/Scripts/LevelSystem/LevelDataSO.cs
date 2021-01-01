using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public abstract class LevelDataSO : ScriptableObject
{
    public string SceneName;

    public virtual void Execute(SceneLoaderManager sceneLoader)
    { 
        sceneLoader.LoadScene(SceneName);
    }
}
