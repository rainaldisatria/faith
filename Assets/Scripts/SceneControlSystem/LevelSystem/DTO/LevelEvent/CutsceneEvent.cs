using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[CreateAssetMenu(menuName = "LevelSystem/CutsceneEvent")]
public class CutsceneEvent : LevelEvent
{   
    [Header("Cutscene Event")]
    [SerializeField] private ManagerSO _cutsceneManagerSO;
    [SerializeField] private PlayableDirector _cutsceneDirector; 

    public override void Execute()
    {
        base.Execute();

        _cutsceneDirector = GameObject.Instantiate<PlayableDirector>(_cutsceneDirector);
        _cutsceneDirector.Play();
    }
}
