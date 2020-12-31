using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public abstract class LevelDataSO : ScriptableObject
{
    [SerializeField] private string _sceneName;

    public virtual void Execute(SceneLoaderManager sceneLoader)
    { 
        sceneLoader.LoadScene(_sceneName);
    }
}
