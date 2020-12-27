using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackController : MonoBehaviour
{ 
    [SerializeField] private Collider _swordCollider; 

    public void AttackStart()
    {
        _swordCollider.gameObject.SetActive(true);
    }

    public void AttackEnded()
    { 
        _swordCollider.gameObject.SetActive(false);
    }
}
