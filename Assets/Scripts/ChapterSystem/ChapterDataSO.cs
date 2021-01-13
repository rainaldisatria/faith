using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneControl/Chapter")]
public class ChapterDataSO : ScriptableObject
{
    public string ChapterName { get => _chapterName; }
    public Sprite Figure { get => _figure; }
    public List<LevelDataSO> LevelsData { get => _levelsData; }

    [SerializeField] private string _chapterName;
    [SerializeField] private Sprite _figure;
    [SerializeField] private List<LevelDataSO> _levelsData;  
}
