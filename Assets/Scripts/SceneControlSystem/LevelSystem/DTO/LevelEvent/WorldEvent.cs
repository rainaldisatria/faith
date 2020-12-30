using UnityEngine;

[CreateAssetMenu(menuName = "LevelSystem/WorldEvent")]
public class WorldEvent : LevelEvent
{
    public string SceneName { get => _sceneName; }

    [SerializeField] private string _sceneName;
}
