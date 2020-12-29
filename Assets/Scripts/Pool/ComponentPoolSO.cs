using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComponentPoolSO<T> : PoolSO<T> where T : Component
{
    private Transform _poolRoot;
    private Transform PoolRoot
    {
        get
        {
            if(_poolRoot == null)
            {
                _poolRoot = new GameObject(name).transform;
                _poolRoot.SetParent(_parent);
            }

            return _poolRoot;
        }
    }

    private Transform _parent;

    public void SetParent(Transform parent)
    {
        _parent = parent;
        PoolRoot.SetParent(_parent);
    }

    public override T Request()
    {
        T member = base.Request();
        member.gameObject.SetActive(true);
        return member;
    }

    public override void Return(T member)
    {
        member.transform.SetParent(PoolRoot.transform);
        member.gameObject.SetActive(false);
        base.Return(member);
    }

    protected override T Create()
    {
        T newMember = base.Create();
        newMember.transform.SetParent(PoolRoot);
        newMember.gameObject.SetActive(false);
        return newMember;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        if (_poolRoot != null)
        {
            DestroyImmediate(_poolRoot.gameObject);
        }
    }
} 
