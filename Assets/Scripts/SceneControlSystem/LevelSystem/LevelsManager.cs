using UnityEngine;

public class LevelsManager : Manager
{
    private LevelData _currentLevelData;
    private int _counter;

    public void Next()
    {
        _counter++;

        if (_counter < _currentLevelData.Events.Count)
        {
            LoadEvent();
        }
    }

    private void LoadEvent()
    {

    }
} 
