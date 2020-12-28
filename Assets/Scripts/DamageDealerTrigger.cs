﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageDealerTrigger : MonoBehaviour
{
    public bool ableToAttack = false;
    private List<GameObject> damagedObject = new List<GameObject>();
    private string userTag;

    private void Awake()
    {
        userTag = gameObject.tag;
    }

    private void OnTriggerEnter(Collider col)
    { 
        DealDamage(col);
    } 

    private void OnTriggerExit(Collider col)
    {
        DealDamage(col);
    }

    private void DealDamage(Collider col)
    { 
        if (ableToAttack)
        {
            if (!col.CompareTag(userTag))
            { 
                if (col.gameObject.GetComponent<IDamageable>() != null)
                {  
                    if (!damagedObject.Contains(col.gameObject))
                    { 
                        damagedObject.Add(col.gameObject);
                        col.gameObject.GetComponent<IDamageable>().TakeDamage(1);
                    }
                }
            }
        }
    }

    public void Enable()
    {
        damagedObject.Clear();
        ableToAttack = true;
    }

    public void Disable()
    {
        ableToAttack = false;
        damagedObject.Clear(); 
    }
}