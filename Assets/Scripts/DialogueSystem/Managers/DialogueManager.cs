using AnthaGames.Assets.Scripts.DialogueSystem.ScriptableObjects;
using UnityEngine;

public class DialogueManager : Manager
{
    public bool IsCompleted { get => _endOfDialogue && _noChoice; }

    [SerializeField] private InputReader _input;
    [SerializeField] private ManagerSO UIDialogueManagerSO;

    private UIDialogueManager _uiDialogueManager; 
    private DialogueData _currentDialogueData;
    private int _counter;
    private bool _noChoice;
    private bool _endOfDialogue { get => _counter >= _currentDialogueData.DialogueLines.Count; }

    private void Start()
    {
        _uiDialogueManager = ((UIDialogueManager)(UIDialogueManagerSO.Manager));
    }

    public void DisplayDialogue(DialogueData dialogueData)
    { 
        _currentDialogueData = dialogueData;
        ResetDialogueManager();

        _input.EnableDialogueInput();
        _input.AdvanceDialogue += AdvanceDialogue;

        _uiDialogueManager.ShowDialogueBox(_currentDialogueData.DialogueLines[_counter]);
    }

    public void AdvanceDialogue()
    {
        _counter++;

        if (_counter < _currentDialogueData.DialogueLines.Count)
            _uiDialogueManager.ShowDialogueBox(_currentDialogueData.DialogueLines[_counter]);

        if (_endOfDialogue)
        {
            if (_currentDialogueData.Choices.Count > 0)    // If there are any choices that player has to made.
            {
                _uiDialogueManager.DisplayChoices(_currentDialogueData.Choices);
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void EndDialogue()
    {
        _noChoice = true;
        _uiDialogueManager.CloseDialogueBox();
        _input.AdvanceDialogue -= AdvanceDialogue;
        _input.EnableGameplayInput();
    }

    private void ResetDialogueManager()
    { 
        _counter = 0;
        _noChoice = false; 
    }
    #region Helper methods
    #endregion 
}
