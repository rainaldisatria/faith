using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueData _dialogueData;
    [SerializeField] private ManagerSO _dialogueManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ((DialogueManager)(_dialogueManager.Manager)).DisplayDialogue(_dialogueData); 
        }
    } 
}
