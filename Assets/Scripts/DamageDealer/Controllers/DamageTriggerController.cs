using UnityEngine;

public class DamageTriggerController
{
    [SerializeField] private DamageDealerTrigger[] _triggers;

    public DamageTriggerController(DamageDealerTrigger[] triggers)
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
