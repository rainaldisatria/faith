using UnityEngine;

public class DamageDealer : IDamageDealer
{
    [SerializeField] private DamageDealerTrigger[] _triggers;

    public DamageDealer(DamageDealerTrigger[] triggers)
    {
        _triggers = triggers;
    }

    public void DealDamageStart()
    {
        foreach (DamageDealerTrigger trigger in _triggers)
            trigger.Enable();
    }

    public void DealDamageEnded()
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
