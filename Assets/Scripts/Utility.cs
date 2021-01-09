using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{  
    public static bool IsUnitWihthinScreenSpace(Vector2 screenPointPos)
    { 
        return screenPointPos.x < Screen.width && screenPointPos.y < Screen.height &&
                   screenPointPos.x > default(float) && screenPointPos.y > default(float);

    }
}
