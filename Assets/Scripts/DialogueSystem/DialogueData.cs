using System;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "New Dialoguedata", menuName = "DialogueSystem/New Dialogue")]
public class DialogueData : ScriptableObject
{    
    public List<DialogueLine> DialogueLines { get => _dialogueLines; }
    public List<Choice> Choices { get => _choices; }

    [SerializeField] private List<DialogueLine> _dialogueLines; 
    [SerializeField] private List<Choice> _choices;
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
    public Actor Actor { get => _actor; }
    public string Sentence { get => _sentence; }

    [SerializeField] private Actor _actor;
    [TextArea(3, 3)] [SerializeField] private string _sentence;
}