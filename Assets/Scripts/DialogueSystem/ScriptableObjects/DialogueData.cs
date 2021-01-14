using System.Collections.Generic;
using UnityEngine;

namespace AnthaGames.Assets.Scripts.DialogueSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Dialoguedata", menuName = "DialogueSystem/New Dialogue")]
    public class DialogueData : ScriptableObject
    {
        public List<DialogueLine> DialogueLines { get => _dialogueLines; }
        public List<Choice> Choices { get => _choices; }

        [SerializeField] private List<DialogueLine> _dialogueLines;
        [SerializeField] private List<Choice> _choices;
    }

}