using System;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "New Level Data", menuName = "ChapterSystem/LevelData")]
[Serializable]
public class LevelData : ScriptableObject
{ 
    public List<LevelEvent> Events;  
}
 