using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour, ITargetable
{
    [SerializeField] private ManagerSO _targetManager;

    private void Update()
    {
        OnObjectOutsideScreenSpace();
        OnObjectWithinScreenSpace();
    }

    public void OnObjectOutsideScreenSpace()
    {
        if (!Utility.IsUnitWihthinScreenSpace(Camera.main.WorldToScreenPoint(transform.position)))
        {
            ((TargetManager)(_targetManager.Manager)).RemoveTarget(transform);
        }
    }

    public void OnObjectWithinScreenSpace()
    {
        if (Utility.IsUnitWihthinScreenSpace(Camera.main.WorldToScreenPoint(transform.position)))
        {
            ((TargetManager)(_targetManager.Manager)).AddTarget(transform);
        }
    }
}
