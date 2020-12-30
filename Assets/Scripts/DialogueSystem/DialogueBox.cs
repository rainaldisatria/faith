using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DialogueBox
{
    public GameObject Go { get => _go; }
    public Image Figure { get => _figure; }
    public Text Name { get => _name; }
    public Text Message { get => _message; }
    public ChoiceBox ChoiceBox { get => _choiceBox; }
    public Button AdvanceButton { get => _advanceButton; }
    

    [SerializeField] private GameObject _go;
    [SerializeField] private Image _figure;
    [SerializeField] private Text _name;
    [SerializeField] private Text _message;
    [SerializeField] private Button _advanceButton;
    [SerializeField] private ChoiceBox _choiceBox;

    public void ShowChoices(List<Choice> responses, DialogueManager dialogueManager)
    { 
        ChoiceBox.Show(responses, dialogueManager); 
    }
}
