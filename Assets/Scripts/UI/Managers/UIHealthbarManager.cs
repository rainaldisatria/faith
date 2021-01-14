using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthbarManager : MonoBehaviour
{ 
    [SerializeField] private HealthbarPoolSO _healthbarPoolSO;
    private readonly List<HealthbarController> _currentlyActiveHealthbars = new List<HealthbarController>();

    [SerializeField] private HealthbarEventChannelSO _healthbarEventChannelSO;
    [SerializeField] private HealthbarFactorySO _healthbarFactorySO;

    private void OnEnable()
    {
        _healthbarEventChannelSO.OnEventRaised += RequestHealthbar;
    }

    private void OnDisable()
    {
        _healthbarEventChannelSO.OnEventRaised -= RequestHealthbar;
    }

    private void Awake()
    {
        _healthbarPoolSO.Factory = _healthbarFactorySO;
        _healthbarPoolSO.Prewarm(5);
        _healthbarPoolSO.SetParent(this.transform);
    }

    public void RequestHealthbar(int instanceID, Transform trans, BattlerData data)
    {
        if (!IsCurrentlyActive(instanceID))
        {
            HealthbarController healthbar = _healthbarPoolSO.Request();
            _currentlyActiveHealthbars.Add(healthbar);

            healthbar.SetHealthbar(instanceID, trans, data);
            healthbar.OnHealthbarFinishedDisplaying += OnHealthbarFinishedPlaying;
        }
    }

    private bool IsCurrentlyActive(int instanceID)
    {
        for(int i = 0; i < _currentlyActiveHealthbars.Count; i++)
        { 
            if(_currentlyActiveHealthbars[i].InstanceID == instanceID)
            {
                _currentlyActiveHealthbars[i].ResetTimer();
                return true;
            } 
        }

        return false;
    }

    private void OnHealthbarFinishedPlaying(HealthbarController healthbar)
    {
        healthbar.OnHealthbarFinishedDisplaying -= OnHealthbarFinishedPlaying;
        _currentlyActiveHealthbars.Remove(healthbar); 
        this._healthbarPoolSO.Return(healthbar);
    }
}
