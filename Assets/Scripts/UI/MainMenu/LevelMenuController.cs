using AnthaGames.Assets.Scripts.ChapterSystem.ScriptableObjects; 
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : MenuWithContent
{
    [SerializeField] private ManagerSO _sceneLoaderManagerSO;

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
                OnLevelButtonClicked(chapter.LevelsData[index]);
            });
        }
    }

    private void OnLevelButtonClicked(LevelDataSO levelData)
    { 
        levelData.Execute(((SceneLoaderManager)_sceneLoaderManagerSO.Manager));
    }
} 
