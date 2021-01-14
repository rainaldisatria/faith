using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthbarPool", menuName = "Pool/Healthbar Pool")]
public class HealthbarPoolSO : ComponentPoolSO<HealthbarController>
{
    [SerializeField] private HealthbarFactorySO _factory;

    public override IFactory<HealthbarController> Factory 
    {
        get
        {
            return _factory;
        }
        set
        {
            _factory = value as HealthbarFactorySO;
        }
    } 
}
