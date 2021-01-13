using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{  
    public static bool IsUnitWihthinScreenSpace(Vector3 screenPointPos)
    { 
        return screenPointPos.x < Screen.width && screenPointPos.y < Screen.height &&
                   screenPointPos.x > default(float) && screenPointPos.y > default(float) &&
                   screenPointPos.z > 0;

    }

    public static void LookAt(Transform obj, Transform objToLookAt)
    {
        obj.LookAt(objToLookAt);
        obj.eulerAngles = new Vector3(0, obj.eulerAngles.y, 0);
    }
}
