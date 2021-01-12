using System.Collections.Generic;
using UnityEngine;

public class UIDialogueManager : Manager
{
    [SerializeField] private DialogueBox _dialogueBox;
    [SerializeField] private ManagerSO _dialogueManagerSO;

    private DialogueManager _dialogueManager;

    private void Start()
    {
        _dialogueManager = ((DialogueManager)(_dialogueManagerSO).Manager);
    }

    /// <summary>
    /// Show dialogue with updated text from DialogueData
    /// </summary>
    public void ShowDialogueBox(DialogueLine dialogueLine)
    {
        _dialogueBox.Go.SetActive(true);

        if (dialogueLine.Actor != null)
        {
            _dialogueBox.Figure.gameObject.SetActive(true);
            _dialogueBox.Name.gameObject.SetActive(true);
            _dialogueBox.Figure.sprite = dialogueLine.Actor.Face;
            _dialogueBox.Name.text = dialogueLine.Actor.name;
        }
        else
        {
            _dialogueBox.Figure.gameObject.SetActive(false);
            _dialogueBox.Name.gameObject.SetActive(false);
        }

        _dialogueBox.Message.text = dialogueLine.Sentence;
    } 

    public void CloseDialogueBox()
    {
        _dialogueBox.Go.SetActive(false);
    } 

    public void DisplayChoices(List<Choice> choices)
    {
        _dialogueBox.ShowChoices(choices, _dialogueManager);
    }
}
