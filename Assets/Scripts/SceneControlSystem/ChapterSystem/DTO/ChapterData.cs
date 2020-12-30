using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChapterSystem/ChapterData", fileName = "New Chapter Data")]
public class ChapterData : ScriptableObject
{ 
    public List<LevelData> Levels; 
}