using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattlerData", menuName = ("Battle/BattlerData"))]
public class BattlerData : ScriptableObject
{ 
    public int MaxHP { get => _maxHP; set => _maxHP = value; }
    public int HP { get => _hp; set => _hp = value; }

    public int MaxSP { get => _maxSP; set => _maxSP = value; }
    public int SP { get => _sp; set => _sp = value; }

    public int Damage { get => _damage; set => _damage = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public List<SkillBaseSO> Skills { get => _skills; set => _skills = value; } 

    [SerializeField] private int _maxHP;
    private int _hp;
    [SerializeField] private int _maxSP;
    private int _sp;
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed; 
    [SerializeField] private List<SkillBaseSO> _skills;

    private void Awake()
    {
        _hp = MaxHP;
        _sp = MaxSP;
    }


}
