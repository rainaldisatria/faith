﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Sword : MonoBehaviour
{
    public bool ableToAttack = false;

    private List<GameObject> damagedObject = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (ableToAttack)
        {
            if (other.CompareTag("Enemy"))
            {
                if (!damagedObject.Contains(other.gameObject))
                {
                    damagedObject.Add(other.gameObject);
                    other.GetComponent<Enemy>().TakeDamage(1);
                }
            }
        }
    }

    public void Enable()
    {
        ableToAttack = true;
    }

    public void Disable()
    {
        ableToAttack = false;
        damagedObject.Clear();

    }
}
