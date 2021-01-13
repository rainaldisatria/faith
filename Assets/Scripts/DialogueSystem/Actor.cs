using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Actor")]
public class Actor : ScriptableObject
{
    public string Name { get => _name; }
    public Sprite Face { get => _face; }

    [SerializeField] private string _name;
    [SerializeField] private Sprite _face;
}
