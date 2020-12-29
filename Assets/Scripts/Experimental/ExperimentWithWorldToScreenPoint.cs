using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentWithWorldToScreenPoint : MonoBehaviour
{
    public Image image; 

    // Update is called once per frame
    void Update()
    {
        image.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
}
