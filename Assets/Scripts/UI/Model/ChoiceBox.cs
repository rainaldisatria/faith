using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ChoiceBox
{ 
    public GameObject Go { get => _go; }
    public Transform ContentTrans { get => _contentTrans; }
    public GameObject ChoiceButton { get => _choiceButton; }

    [SerializeField] private GameObject _go;
    [SerializeField] private Transform _contentTrans;
    [SerializeField] private GameObject _choiceButton;

    public virtual void Show(List<Choice> choices, DialogueManager dialogueManager)
    {
        _go.SetActive(true);

        PrepareChoiceBox(choices, dialogueManager);
    }

    private void PrepareChoiceBox(List<Choice> choices, DialogueManager dialogueManager)
    {
        // Delete all existing choice.
        foreach (Transform child in _contentTrans.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        // Instantiate new choice.
        for(int i = 0; i < choices.Count; i++)
        {
            Button choiceButton = GameObject.Instantiate<Button>(_choiceButton.GetComponent<Button>(), ContentTrans);
            int index = i;
            choiceButton.onClick.AddListener(() => ExecuteResponse(choices[index].Response, dialogueManager));
            choiceButton.GetComponentInChildren<Text>().text = choices[index].OptionName;
        }
    } 

    private void ExecuteResponse(DialogueData dialogueData, DialogueManager dialogueManager)
    {
        if (dialogueData != null)
            dialogueManager.DisplayDialogue(dialogueData);
        else
            dialogueManager.EndDialogue();

        _go.SetActive(false);
    }
}