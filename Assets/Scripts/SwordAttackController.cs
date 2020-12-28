using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackController : MonoBehaviour
{ 
    [SerializeField] private Sword _sword; 

    public void AttackStart()
    { 
        _sword.Enable();
    }

    public void AttackEnded()
    { 
        _sword.Disable();
    }
}
