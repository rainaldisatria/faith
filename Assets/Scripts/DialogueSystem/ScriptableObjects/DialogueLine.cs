using System;
using UnityEngine;

namespace AnthaGames.Assets.Scripts.DialogueSystem.ScriptableObjects
{
    [Serializable]
    public class DialogueLine
    {
        public Actor Actor { get => _actor; }
        public string Sentence { get => _sentence; }

        [SerializeField] private Actor _actor;
        [TextArea(3, 3)] [SerializeField] private string _sentence;
    }
}