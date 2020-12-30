using System;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "New Dialoguedata", menuName = "DialogueSystem/New Dialogue")]
public class DialogueData : ScriptableObject
{    
    public List<DialogueLine> DialogueLines;
    [Tooltip("Leave this empty if dialogue has no branch.")]
    public List<Choice> Choices;
} 

[Serializable]
public class Choice
{
    public string OptionName { get => _optionName; }
    public DialogueData Response { get => _response; }

    [SerializeField] private string _optionName;
    [SerializeField] private DialogueData _response;
}

[Serializable]
public class DialogueLine
{
    public Actor Actor; 
    [TextArea(3, 3)] public string Sentence;  
}