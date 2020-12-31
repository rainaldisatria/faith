using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experiment : MonoBehaviour
{
    public Collider[] colliders;

    private void Awake()
    {
        colliders = GetComponentsInChildren<Collider>();
    }
}
