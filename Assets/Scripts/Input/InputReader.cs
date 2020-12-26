using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="InputReader", menuName ="Input/InputReader")]
public class InputReader : ScriptableObject
{
    private GameInput gameInput;

    private void OnEnable()
    {
        if(gameInput == null)
        {
            gameInput = new GameInput();
        }
    }
}
