using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _chapterButtonPrefab;
    [SerializeField] private List<ChapterDataSO> _chapters;
    [SerializeField] private Transform _contentTrans;

    private void OnEnable()
    {
        for(int i = 0; i < _chapters.Count; i++)
        { 
            GameObject _chapterObj = Instantiate(_chapterButtonPrefab, _contentTrans);
            _chapterObj.name = _chapters[i].name;

            _chapterObj.transform.Find("Name").GetComponent<TMP_Text>().text = _chapters[i].name;
            _chapterObj.GetComponent<Button>().onClick.AddListener(delegate
            {
                OnChapterButtonClicked(_chapters[i]);
            });
        }
    }

    private void OnDisable()
    {
        
    }

    private void OnChapterButtonClicked(ChapterDataSO chapterData)
    {
        for (int j = 0; j < chapterData.LevelsData.Count; j++)
        {
        }
    }
}
