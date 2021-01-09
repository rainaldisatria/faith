using System.Collections.Generic;
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
        if(Target != null)
        {
            Debug.Log(Target);
        }

        if (Targets.Count <= 0)
            return;

        if (GetNearestTargetID() == -1)
            return;

        Target = Targets[GetNearestTargetID()];

        if (Target != null)
        {
            _targetImage.gameObject.SetActive(true);
            _targetImage.transform.position = Camera.main.WorldToScreenPoint(Target.position);
        } 
    }

    private int GetNearestTargetID()
    {
        int index = -1;
        float[] distances = new float[Targets.Count];

        for(int i = 0; i < Targets.Count; i++)
        {
            if(Targets[i] != null)
                distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(Targets[i].position), new Vector2(Screen.width / 2, Screen.height / 2)); 
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
