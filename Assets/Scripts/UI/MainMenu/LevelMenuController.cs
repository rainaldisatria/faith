using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : MenuWithContent
{ 
    public void Open(ChapterDataSO chapter)
    { 
        for (int i = 0; i < chapter.LevelsData.Count; i++)
        {
            GameObject _levelObj = Instantiate(Prefab, ContentTrans);
            _levelObj.name = chapter.LevelsData[i].name;

            _levelObj.transform.Find("Title").GetComponent<TMP_Text>().text = chapter.LevelsData[i].name;

            int index = i;
            _levelObj.GetComponent<Button>().onClick.AddListener(delegate 
            {
                OnChapterButtonClicked(chapter.LevelsData[index]);
            });
        }
    }

    private void OnChapterButtonClicked(LevelDataSO levelData)
    {
        levelData.Execute();
    }
} 
