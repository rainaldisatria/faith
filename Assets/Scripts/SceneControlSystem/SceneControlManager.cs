using System.Collections.Generic;
using UnityEngine;
 
public class SceneControlManager : Manager
{ 
    private ChaptersData _chaptersData;

    #region Counter fields
    private int _subLevelCounter;
    private int _levelCounter;
    private int _chapterCounter;
    #endregion

    #region Properties
    private bool EndOfLevelEvents
    {
        get => _subLevelCounter >= _chaptersData.Chapters[_chapterCounter].Levels[_levelCounter].Events.Count;
    }

    private bool EndOfChapter
    {
        get => _levelCounter >= _chaptersData.Chapters[_chapterCounter].Levels.Count;
    }

    private bool EndOfChapters
    {
        get => _chapterCounter >= _chaptersData.Chapters.Count; 
    }
    #endregion

    public void Next()
    {
        _subLevelCounter++;
        PrepareToExecute();
    } 

    public void PlayChaptersData(ChaptersData chaptersData)
    {
        PrepareToPlay();
        _chaptersData = chaptersData;

        PrepareToExecute();
    }

    public void PlayChapterData(ChapterData chapterData)
    {
        PrepareToPlay();
        _chaptersData = ScriptableObject.CreateInstance<ChaptersData>();
        _chaptersData.Chapters = new List<ChapterData>() { chapterData };

        PrepareToExecute();
    }

    public void PlayLevelData(LevelData levelData)
    {
        PrepareToPlay();
        _chaptersData = ScriptableObject.CreateInstance<ChaptersData>();
        _chaptersData.Chapters = new List<ChapterData>() { ScriptableObject.CreateInstance<ChapterData>() };
        _chaptersData.Chapters[0].Levels = new List<LevelData>() { levelData };

        PrepareToExecute();
    }

    private void PrepareToExecute()
    { 
        if (EndOfLevelEvents)
        {
            _subLevelCounter = 0;
            _levelCounter++;

            if (EndOfChapter)
            {
                _subLevelCounter = 0;
                _levelCounter = 0;
                _chapterCounter++;

                if (EndOfChapter)
                {
                    Debug.Log("Ended");
                }
                else
                {
                    Execute();
                }

            }
            else
            {
                Execute();
            }
        }
        else
        {
            Execute();
        }
    }

    private void PrepareToPlay()
    { 
        _subLevelCounter = 0;
        _levelCounter = 0;
        _chapterCounter = 0;
    }

    private void Execute()
    {
        _chaptersData.Chapters[_chapterCounter].Levels[_levelCounter].Events[_subLevelCounter].Execute();
    }
}
