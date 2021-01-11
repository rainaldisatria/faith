using System.Collections;
using UnityEngine;

public interface ISkill
{
    IEnumerator Execute(Battler battler, Transform target);
}
