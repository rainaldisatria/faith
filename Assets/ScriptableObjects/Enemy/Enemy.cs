using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Data
    private int health = 100; 

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage " + damage);
        health -= damage;
    }
}
