using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageDealerTrigger : MonoBehaviour
{
    private bool ableToAttack = false;
    private List<GameObject> damagedObject = new List<GameObject>();
    private string _userTag;
    private int _damage;

    [SerializeField] private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _userTag = gameObject.transform.root.tag; 
    }

    private void OnTriggerStay(Collider col)
    { 
        DealDamage(col);
    }

    public void SetUserTag(string userTag)
    {
        _userTag = userTag;
    }

    private void DealDamage(Collider col)
    { 
        if (ableToAttack)
        {
            if (!col.CompareTag(_userTag))
            { 
                if (col.gameObject.GetComponent<IDamageable>() != null)
                {  
                    if (!damagedObject.Contains(col.gameObject))
                    { 
                        damagedObject.Add(col.gameObject);
                        col.gameObject.GetComponent<IDamageable>().TakeDamage(_damage, transform.root);

                        col.transform.DOMove(col.transform.position + transform.root.forward, .5f);
                    }
                }
            }
        }
    }

    public void Enable(int damage)
    {
        if (_trailRenderer != null)
            _trailRenderer.emitting = true;
        _damage = damage;
        damagedObject.Clear();
        ableToAttack = true;  
    }

    public void Disable()
    {
        if (_trailRenderer != null)
            _trailRenderer.emitting = false;
        damagedObject.Clear();
        ableToAttack = false; 
    } 
}
