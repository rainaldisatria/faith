using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experiment : MonoBehaviour
{
    public UnityEvent action;
    public UnityEvent Action2;

    private void OnEnable()
    {
        action?.Invoke();
    }

    private void OnDisable()
    {
        Action2?.Invoke();
    }
}
