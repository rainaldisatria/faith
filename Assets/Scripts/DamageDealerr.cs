using UnityEngine;

public class DamageDealer : IDamageDealer
{
    [SerializeField] private DamageDealerTrigger[] _triggers;

    public DamageDealer(DamageDealerTrigger[] triggers)
    {
        _triggers = triggers;
    }

    public void DealDamageStart(int damage)
    {
        foreach (DamageDealerTrigger trigger in _triggers)
            trigger.Enable(damage);
    }

    public void DealDamageEnded()
    {
        foreach (DamageDealerTrigger trigger in _triggers)
            trigger.Disable();
    }
}

public interface IDamageDealer
{ 
    void DealDamageStart(int damage);
    void DealDamageEnded();
}
