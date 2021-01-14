using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class UIManager : Manager
{
    [SerializeField] private ChapterMenuController _chapterMenu;
    [SerializeField] private CreditMenuController _creditMenu;
    [SerializeField] private LevelMenuController _levelMenu;    

    public void OpenCreditMenu()
    {
        _creditMenu.OpenCreditMenu();
    }

    public void OpenLevelMenu(ChapterDataSO chapter)
    {
        _levelMenu.Open(chapter);
    }
}
