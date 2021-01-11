using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : Manager
{
    [SerializeField] private Image _targetImage;
    [SerializeField] private Image _camTargetImage;
    [SerializeField] private Transform _playerTrans; 

    private List<Transform> Targets = new List<Transform>();
    public Transform Target { get; private set; }
    public Transform CamTarget { get; private set; }

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
        Targets.RemoveAll(item => item == null);

        if (Targets.Count <= 0)
        {
            Target = null;
            CamTarget = null;
            return;
        }

        Target = GetNearestTarget();
        CamTarget = GetNearestCamTarget(); 

        if (CamTarget != null)
        {
            _camTargetImage.gameObject.SetActive(true);
            _camTargetImage.transform.position = Camera.main.WorldToScreenPoint(CamTarget.position + new Vector3(0, 0, 0));
        }
        else 
        {
            _camTargetImage.gameObject.SetActive(false);
        } 
    }
     
    private Transform GetNearestCamTarget()
    {
        if (Targets.Count <= 0)
            return null;

        int index = 0;
        float[] distances = new float[Targets.Count];

        for (int i = 0; i < distances.Length; i++)
        {
            if (Targets[i] != null) 
                distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(Targets[i].position), new Vector2(Screen.width / 2, Screen.height / 2)); 
        }

        float minDistance = Mathf.Min(distances);

        for (int i = 0; i < distances.Length; i++)
        {
            if (minDistance == distances[i])
            {
                index = i;
            }
        }

        return Targets[index];
    }

    private Transform GetNearestTarget()
    {
        int index = 0;

        float[] distances = new float[Targets.Count]; 
        for (int i = 0; i < distances.Length; i++)
        {
            if (Targets[i] != null && Targets[i].root.CompareTag("Enemy"))
                distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(Targets[i].position), _playerTrans.transform.forward);
            else
                distances[i] = float.MaxValue;
        }

        float minDistance = Mathf.Min(distances);
        if (minDistance == float.MaxValue)
            return null;

        for(int i = 0; i < distances.Length; i++)
        {
            if(minDistance == distances[i])
            {
                index = i;
            }
        }

        return Targets[index].root;
    }
}
