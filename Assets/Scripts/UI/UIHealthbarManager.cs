using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthbarManager : MonoBehaviour
{ 
    [SerializeField] private HealthbarPoolSO _healthbarPoolSO;

    private void Awake()
    {
        _healthbarPoolSO.Prewarm(5);
        _healthbarPoolSO.SetParent(this.transform);
    }
}
