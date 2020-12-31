using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterMenuController : MenuWithContent
{
    [SerializeField] private LevelMenuController LevelMenuController;

    [SerializeField] private List<ChapterDataSO> _chapters; 

    private void OnEnable()
    {
        Open(); 
    } 

    #region Helper methods
    private void OnChapterButtonClicked(ChapterDataSO chapterData)
    {
        LevelMenuController.gameObject.SetActive(true);
        LevelMenuController.Open(chapterData);
    }

    public void Open()
    { 
        for (int i = 0; i < _chapters.Count; i++)
        {
            GameObject _chapterObj = Instantiate(Prefab, ContentTrans);
            _chapterObj.name = _chapters[i].name;

            _chapterObj.transform.Find("Mask").Find("Image").GetComponent<Image>().sprite = _chapters[i].Figure;
            _chapterObj.transform.Find("Title").GetComponent<TMP_Text>().text = _chapters[i].name;
            _chapterObj.transform.Find("Subtitle").GetComponent<TMP_Text>().text = $"Total level: {_chapters[i].LevelsData.Count}";

            int index = i; 
            _chapterObj.GetComponent<Button>().onClick.AddListener(delegate
            {
                OnChapterButtonClicked(_chapters[index]);
            }); 
        }
    } 
    #endregion
}
