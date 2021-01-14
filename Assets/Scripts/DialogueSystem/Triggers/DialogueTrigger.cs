using AnthaGames.Assets.Scripts.DialogueSystem.ScriptableObjects;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private DialogueData _dialogueData;
    [SerializeField] private ManagerSO _dialogueManager; 

    private void OnTriggerEnter(Collider other)
    { 
        if (IsPlayer(other))
        { 
            EnableInteraction(other);
        }
    } 

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        { 
            DisableInteraction();
        }
    }

    private void EnableInteraction(Collider other)
    {
        _inputReader.InteractEvent += PlayDialogue;
    }

    private void DisableInteraction()
    {
        _inputReader.InteractEvent -= PlayDialogue;
    }

    private void PlayDialogue()
    {
        ((DialogueManager)(_dialogueManager.Manager)).DisplayDialogue(_dialogueData);
    }

    private bool IsPlayer(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            return true;

        return false;
    }
}
