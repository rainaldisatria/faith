using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneControl/Chapter")]
public class ChapterDataSO : ScriptableObject
{
    public Sprite Figure { get => _figure; }
    public List<LevelDataSO> LevelsData { get => _levelsData; }

    [SerializeField] private Sprite _figure;
    [SerializeField] private List<LevelDataSO> _levelsData;  
}
