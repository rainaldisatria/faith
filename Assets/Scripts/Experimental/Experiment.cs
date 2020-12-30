using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment : MonoBehaviour
{
    public SkinnedMeshRenderer[] skins;

    // Start is called before the first frame update
    void Start()
    {
        skins = GetComponentsInChildren<SkinnedMeshRenderer>();
    } 
}
