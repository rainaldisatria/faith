using UnityEngine;

public class DialogueManager : Manager
{
    public bool IsCompleted { get => _endOfDialogue && _noChoice; }

    [SerializeField] private InputReader _input;
    [SerializeField] private DialogueBox _dialogueBox;

    private DialogueData _currentDialogueData;
    private int _counter;
    private bool _noChoice;
    private bool _endOfDialogue { get => _counter >= _currentDialogueData.DialogueLines.Count; } 

    public void DisplayDialogue(DialogueData dialogueData)
    { 
        _currentDialogueData = dialogueData;
        ResetDialogueManager();

        _input.EnableDialogueInput();
        _input.AdvanceDialogue += AdvanceDialogue;

        PrepareDialogueBox();
    }

    private void ResetDialogueManager()
    { 
        _counter = 0;
        _noChoice = false; 
    }

    public void AdvanceDialogue()
    { 
        _counter++;

        if (_counter < _currentDialogueData.DialogueLines.Count)
            PrepareDialogueBox();

        if (_endOfDialogue)
        {
            if(_currentDialogueData.Choices.Count > 0)    // If there are any choices that player has to made.
            {
                DisplayChoices();
            }
            else
            {
                DialogueEnded();
            }
        }
    }

    public void DialogueEnded()
    { 
        _noChoice = true;
        CloseDialogueBox();
        _input.AdvanceDialogue -= AdvanceDialogue;
        _input.EnableGameplayInput();
    }

    public void CloseDialogueBox()
    {
        _dialogueBox.Go.SetActive(false);
    }

    public void DisplayChoices()
    {
        _dialogueBox.ShowChoices(_currentDialogueData.Choices, this); 
    }

    #region Helper methods
    /// <summary>
    /// Show dialogue with updated text from DialogueData
    /// </summary>
    private void PrepareDialogueBox()
    {
        _dialogueBox.Go.SetActive(true);

        if (_currentDialogueData.DialogueLines[_counter].Actor != null)
        {
            _dialogueBox.Figure.gameObject.SetActive(true);
            _dialogueBox.Name.gameObject.SetActive(true);
            _dialogueBox.Figure.sprite = _currentDialogueData.DialogueLines[_counter].Actor.Sprite;
            _dialogueBox.Name.text = _currentDialogueData.DialogueLines[_counter].Actor.name;
        }
        else
        { 
            _dialogueBox.Figure.gameObject.SetActive(false);
            _dialogueBox.Name.gameObject.SetActive(false);
        }

        _dialogueBox.Message.text = _currentDialogueData.DialogueLines[_counter].Sentence;
    }
    #endregion 
}
