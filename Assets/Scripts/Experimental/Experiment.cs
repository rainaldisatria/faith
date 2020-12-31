using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experiment : MonoBehaviour
{
    public UnityEvent action;
    public float actionDelay;

    public UnityEvent Action2;
    public float actonDelay2; 

    private IEnumerator ActionDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    private IEnumerator Action2Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Action2?.Invoke();
    }
}
