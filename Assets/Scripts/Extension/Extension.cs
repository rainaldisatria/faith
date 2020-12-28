using System; 
using UnityEngine;  

public static class ExtensionMethods
{  
    #region Animators
    public static void PlayAll(this Animator[] animators, Action<int> action) 
    {
        for (int i = 0; i < animators.Length; i++)
        {
            action(i);
        }
    } 
    #endregion
}
