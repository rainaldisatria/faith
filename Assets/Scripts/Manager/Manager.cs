using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public abstract class Manager : MonoBehaviour
{
    [SerializeField] protected ManagerSO _managerSO;

    protected virtual void Awake()
    {
        if(_managerSO != null)
            _managerSO.Manager = this; 
    }
}
