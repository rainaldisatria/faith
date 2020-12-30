using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Damage Skill")]
public class DamageSkillSO : SkillBaseSO
{
    [SerializeField] private int damage;

    private bool isPlaying;

    public override IEnumerator Execute(Transform posToExecute)
    { 
        if (!isPlaying)
        {
            isPlaying = true;
            yield return new WaitForSeconds(delay);
            Instantiate(_effect); 
            isPlaying = false;
        } 
    } 
}
