using UnityEngine;

public class SwordController : MonoBehaviour
{ 
    [SerializeField] private Sword[] _swords; 

    public void AttackStart()
    {
        Debug.Log("Started");
        foreach(Sword sword in _swords)
            sword.Enable();
    }

    public void AttackEnded()
    {
        Debug.Log("Enhded");
        foreach (Sword sword in _swords)
            sword.Disable();
    }
}
