using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattlerData", menuName = ("Battle/BattlerData"))]
public class BattlerData : ScriptableObject
{
    public int MaxHP;
    [HideInInspector] public int HP;
    public int MaxSP;
    [HideInInspector] public int SP;
    public int Damage;
    public float MoveSpeed;

    public List<SkillBaseSO> Skills;

    private void Awake()
    {
        HP = MaxHP;
    }
}
