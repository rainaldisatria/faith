﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : Manager
{
    [SerializeField] private Image _targetImage; 
    [SerializeField] private Transform _playerTrans; // If relative to player trans.

    public List<Transform> Targets = new List<Transform>();
    public Transform Target { get; private set; }

    public void AddTarget(Transform target)
    {
        if (!Targets.Contains(target))
        {
            Targets.Add(target);
        }
    }

    public void RemoveTarget(Transform target)
    {
        Targets.Remove(target);
    }

    private void Update()
    {
        if (Targets.Count <= 0)
        {
            Target = null;
            return;
        }
             
        Target = Targets[GetNearestTargetID()];

        if (Target != null)
        {
            _targetImage.gameObject.SetActive(true);
            _targetImage.transform.position = Camera.main.WorldToScreenPoint(Target.position + new Vector3(0, 1, 0));
        }
        else
        {
            _targetImage.gameObject.SetActive(false); 
        }


    }

    private int GetNearestTargetID()
    { 
        if (Targets.Count <= 0)
            return -1;

        int index = -1;
        float[] distances = new float[Targets.Count];

        for (int i = 0; i < distances.Length; i++)
        {
            if (Targets[i] != null)
                distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(Targets[i].position), new Vector2(Screen.width / 2, Screen.height / 2));
            else
                Targets.RemoveAt(i);
        }

        float minDistance = Mathf.Min(distances);

        for(int i = 0; i < distances.Length; i++)
        {
            if(minDistance == distances[i])
            {
                index = i;
            }
        }

        return index;
    }
}
