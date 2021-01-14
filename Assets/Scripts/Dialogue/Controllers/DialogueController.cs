using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
/*

using UnityEngine.UI;

[Serializable]
public class DialogueBox
{ 
    [SerializeField] public GameObject DialogueObject;
    [SerializeField] public Text Message;
    [SerializeField] public Text Name;
    [SerializeField] public Image Actor;
    [SerializeField] public Button DialogueButton;
}

public class DialogueController : MonoBehaviour
{
    public DialogueData DialogueData;
    public PlayableDirector Director;
    public int Counter;

    [SerializeField] private DialogueBox _dialogueBox;
    [SerializeField] private DialogueBox _dialogueBoxWithFace;
    private DialogueBox _usedDialogueBox;

    private bool _isAlreadyShowing = false; 

    private void Start()
    {
        Counter = 0;

        DialogueData = GameManager.Current.SelectedLevel.Data.Sub[GameManager.Current.SelectedLevel.Counter].DialogueData;

        if (DialogueData.Cutscene != null)
        {
            Director.Play(DialogueData.Cutscene);
        }

        _usedDialogueBox = _dialogueBox;
    }

    #region Timeline related methods.
    public void Pause()
    {
        Director.playableGraph.GetRootPlayable(0).SetSpeed(0);  
    }

    public void Resume()
    {
        Director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
    #endregion


    public void SetDialogueBox(bool condition)
    {
        if (condition && !_isAlreadyShowing)
        {
            StartCoroutine(ShowDialogueBox());
        }
        else if (condition == false)
        {
            _isAlreadyShowing = false;
            _usedDialogueBox.DialogueObject.SetActive(false);
        }
    }

    private IEnumerator ShowDialogueBox()
    {
        _isAlreadyShowing = true;

        ClearDialogueBox();

        yield return new WaitForSeconds(0.25f);

        UpdateDialogueBox(); 
    }

    public void Next()
    {
        _usedDialogueBox.DialogueObject.SetActive(false);

        if(Counter < DialogueData.Dialogue.Count - 1)
        {
            Counter++;
            UpdateDialogueBox(); 
        }
        else
        {
            GameManager.Current.SelectedLevel.Next();
        }
    }

    public void SetCounter(int id)
    {
        Counter = id;
        UpdateDialogueBox();
    }

    #region Helper methods.
    private void ClearDialogueBox()
    {
        _usedDialogueBox.DialogueObject.SetActive(false);
         
        _usedDialogueBox.Message.gameObject.SetActive(false);
        _usedDialogueBox.Message.text = string.Empty;

        _usedDialogueBox.Actor.gameObject.SetActive(false);
        _usedDialogueBox.Actor.sprite = null;

    }

    private void UpdateDialogueBox()
    {
        _usedDialogueBox.DialogueObject.SetActive(false);

        if (DialogueData.Dialogue[Counter].Actor != null)
        {
            _usedDialogueBox = _dialogueBox;

            if (DialogueData.Dialogue[Counter].Actor.Sprite != null)
            {
                _usedDialogueBox = _dialogueBoxWithFace;

                _usedDialogueBox.Actor.sprite = DialogueData.Dialogue[Counter].Actor.Sprite;
                _usedDialogueBox.Actor.gameObject.SetActive(true);
            } 

            _usedDialogueBox.Name.text = DialogueData.Dialogue[Counter].Actor.name;
            _usedDialogueBox.Name.gameObject.SetActive(true);
        }
        else
        {
            _usedDialogueBox = _dialogueBox;
        }
        
        _usedDialogueBox.Message.text = DialogueData.Dialogue[Counter].Sentence;
        _usedDialogueBox.Message.gameObject.SetActive(true);

        _usedDialogueBox.DialogueObject.SetActive(true);
    }
    #endregion
}

    */