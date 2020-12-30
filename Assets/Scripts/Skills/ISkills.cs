using System.Collections;
using UnityEngine;

public interface ISkills
{
    IEnumerator Execute(Transform posToExecute);
}
