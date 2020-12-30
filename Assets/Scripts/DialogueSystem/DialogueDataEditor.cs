﻿using Malee.List;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueData))]
public class DialogueDataEditor : Editor
{
    private readonly Type _dialogueData = typeof(DialogueData);

    /// <summary>
    /// All serialized fields in <see cref="DialogueData"/>
    /// </summary>
    private readonly List<SerializedProperty> _serializedFields = new List<SerializedProperty>();

    #region Dialogue Data
    private ReorderableList DialogueList;
    private ReorderableList ResponsesList;
    #endregion


    private void OnEnable()
    {
        PrepareSerializedProperty();
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawCustomInspector();
    }

    /// <summary>
    /// Determines how the new custom inspector will be displayed.
    /// </summary>
    private void DrawCustomInspector()
    {
        // Make GUI not changeable.
        GUI.enabled = false;

        // Draw reference information about script being edited.
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((DialogueData)target), typeof(DialogueData), false);

        // Make GUI changeable
        GUI.enabled = true;

        serializedObject.Update();

        // Draw field to display
        foreach (SerializedProperty field in this._serializedFields)
        {
            if (field != null)
            {
                if (field.name == nameof(DialogueData.DialogueLines))
                {
                    DialogueList.DoLayoutList(); 
                }
                else if (field.name == nameof(DialogueData.Choices))
                {
                    ResponsesList.DoLayoutList();
                }
                else  // Draw Default property fields.
                {
                    EditorGUILayout.PropertyField(field);
                }
            }
        }

        serializedObject.ApplyModifiedProperties(); 
    }

    /// <summary>
    /// Identify all serialized property from selected <see cref="DialogueData"/>
    /// </summary>
    private void PrepareSerializedProperty()
    {
        // Prepare serialized property.
        FieldInfo[] fields = this._dialogueData.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            SerializedProperty serializedProperty = this.serializedObject.FindProperty(field.Name);

            this._serializedFields.Add(serializedProperty);

            if (field.Name == nameof(DialogueData.DialogueLines))
            {
                DialogueList = new ReorderableList(serializedProperty);
            } 
            else if (field.Name == nameof(DialogueData.Choices))
            {
                ResponsesList = new ReorderableList(serializedProperty);
            }
        }
    }
} 