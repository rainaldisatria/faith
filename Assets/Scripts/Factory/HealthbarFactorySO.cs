using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthbarFactory", menuName = "Factory/Healthbar Factory")]
public class HealthbarFactorySO : FactorySO<HealthbarController>
{
    public HealthbarController prefab;

    public override HealthbarController Create()
    {
        return Instantiate(prefab);
    }
}
