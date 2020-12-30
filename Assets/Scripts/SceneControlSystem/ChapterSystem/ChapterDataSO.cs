using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneControl/Chapter")]
public class ChapterDataSO : ScriptableObject
{
    public List<LevelDataSO> LevelsData { get => _levelsData; }

    [SerializeField] private List<LevelDataSO> _levelsData;  
}
