using UnityEngine;
using UnityEngine.UI;

public class ChapterButtonController : MonoBehaviour
{
    #region Managers
    [SerializeField] private ManagerSO _sceneControlManagerSO;
    private SceneControlManager _sceneControlManager;
    #endregion

    [SerializeField] private ChapterData _chapterData;

    [SerializeField] private GameObject _chapterMenuObject;
    [SerializeField] private GameObject _chapterMenuContent;
    [SerializeField] private GameObject _levelSlotButtonPrefab;

    #region Temporary variable 
    private Button _tempButton; 
    #endregion   

    private void Start()
    { 
        GetComponent<Button>().onClick.AddListener(OnClick);
        _sceneControlManager = _sceneControlManagerSO.Manager as SceneControlManager;
    }

    public void OnClick()
    {
        _chapterMenuObject.SetActive(true);
        PrepareLevelButton();
    }

    private void PrepareLevelButton()
    {
        foreach(Transform child in _chapterMenuContent.transform)
        {
            if(child != null)
                Destroy(child.gameObject);
        }

        for(int i = 0; i < _chapterData.Levels.Count; i++)
        { 
            _tempButton = Instantiate(_levelSlotButtonPrefab.GetComponent<Button>(), _chapterMenuContent.transform);

            _tempButton.GetComponentInChildren<Text>().text = _chapterData.Levels[i].name;

            int index = i;
            _tempButton.onClick.AddListener(() => 
            {
                _sceneControlManager.PlayLevelData(_chapterData.Levels[index]); 
            });

            //_tempButton.interactable = GameManager.Current.SaveData.ChapterSaveData.Chapters[_chapterData.name].LevelData[_chapterData.Levels[i].name];
        }
    }
}
