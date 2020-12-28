using UnityEngine;

public class SwordController : MonoBehaviour
{ 
    [SerializeField] private Sword[] _swords; 

    public void AttackStart()
    { 
        foreach(Sword sword in _swords)
            sword.Enable();
    }

    public void AttackEnded()
    { 
        foreach(Sword sword in _swords)
            sword.Disable();
    }
}
