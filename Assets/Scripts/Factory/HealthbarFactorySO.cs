using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthbarFactory", menuName = "Factory/Healthbar Factory")]
public class HealthbarFactorySO : FactorySO<Healthbar>
{
    public Healthbar prefab;

    public override Healthbar Create()
    {
        return Instantiate(prefab);
    }
}
