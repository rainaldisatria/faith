using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Sword : MonoBehaviour
{
    public bool ableToAttack = false;

    private List<GameObject> damagedObject = new List<GameObject>(); 
    
    private void OnCollisionEnter(Collision col)
    { 
        Damage(col);
    }

    private void OnCollisionStay(Collision collision)
    {
        Damage(collision);
    }

    private void OnCollisionExit(Collision col)
    {
        Damage(col);
    }

    private void Damage(Collision col)
    {
        if (ableToAttack)
        {
            if (col.gameObject.GetComponent<IDamageable>() != null)
            {
                if (!damagedObject.Contains(col.gameObject))
                {
                    damagedObject.Add(col.gameObject);
                    col.gameObject.GetComponent<IDamageable>().TakeDamage(1);
                }
            }
        }
    }

    public void Enable()
    {
        ableToAttack = true;
    }

    public void Disable()
    {
        ableToAttack = false;
        damagedObject.Clear(); 
    }
}
