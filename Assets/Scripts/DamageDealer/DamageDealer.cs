using UnityEngine;

public class DamageDealer
{
    [SerializeField] private DamageDealerTrigger[] _triggers;

    public DamageDealer(DamageDealerTrigger[] triggers)
    {
        _triggers = triggers;
    }

    public void Start(int damage)
    {
        foreach (DamageDealerTrigger trigger in _triggers)
            trigger.Enable(damage);
    }

    public void End()
    {
        foreach (DamageDealerTrigger trigger in _triggers)
            trigger.Disable();
    } 
}

public interface IDamageDealer
{ 
    void DealDamageStart();
    void DealDamageEnded(); 
}
