using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private DialogueData _dialogueData;
    [SerializeField] private ManagerSO _dialogueManager;

    private Quaternion defaultQuaternion; 

    private void Awake()
    {
        defaultQuaternion = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        { 
            EnableInteraction(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsPlayer(other))
        {
            transform.LookAt(other.transform);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y, 0), 1);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        transform.rotation = defaultQuaternion;
        DisableInteraction();
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
