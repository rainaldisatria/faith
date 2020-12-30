using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBaseSO : ScriptableObject, ISkills
{
    [SerializeField] protected string _skillName;
    [SerializeField] protected GameObject _effect;
    [SerializeField] protected float delay;

    public string SkillName { get => _skillName;}

    public abstract IEnumerator Execute(Transform posToExecute);
}
