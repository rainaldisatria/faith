using System;
using UnityEngine;

[Serializable]
public class Choice
{
    public string OptionName { get => _optionName; }
    public DialogueData Response { get => _response; }

    [SerializeField] private string _optionName;
    [SerializeField] private DialogueData _response;
}
