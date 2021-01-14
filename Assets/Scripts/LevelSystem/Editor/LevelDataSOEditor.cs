using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(LevelDataSO), true)]
public class LevelDataSOEditor : Editor
{
    private Type _levelEvent = typeof(LevelDataSO);

    private const string NoSceneWarning = "There is no Scene associated to this location yet. Add a new scene with the dropdown below";
    private static readonly string[] ExcludedProperties = { "m_Script", "_sceneName" };

    private LevelDataSO _selectedLevelEvent;
    private string[] _sceneList;

    private void OnEnable()
    {
        _selectedLevelEvent = (LevelDataSO)target;
        PrepareSceneList();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Make GUI not changeable.
        GUI.enabled = false;
        // Draw reference information about script being edited.
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((LevelDataSO)target), typeof(LevelDataSO), false);
        // Make GUI changeable
        GUI.enabled = true;

        DrawSceneList();
        DrawPropertiesExcluding(serializedObject, ExcludedProperties);

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawSceneList()
    {
        SerializedProperty sceneNameField = this.serializedObject.FindProperty("_sceneName");
        var sceneName = sceneNameField.stringValue;
        EditorGUI.BeginChangeCheck();
        var selectedScene = _sceneList.ToList().IndexOf(sceneName);

        if (selectedScene < 0)
        {
            EditorGUILayout.HelpBox(NoSceneWarning, MessageType.Warning);
        }

        selectedScene = EditorGUILayout.Popup("Scene", selectedScene, _sceneList);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed selected scene");
            sceneNameField.stringValue = _sceneList[selectedScene];
            MarkAllDirty();
        }
    }

    /// <summary>
    /// Populates the Scene picker with Scenes included in the game's build index
    /// </summary>
    private void PrepareSceneList()
    {
        var sceneCount = SceneManager.sceneCountInBuildSettings;
        _sceneList = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            _sceneList[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }

    /// <summary>
    /// Marks scenes as dirty so data can be saved
    /// </summary>
    private void MarkAllDirty()
    {
        EditorUtility.SetDirty(target);
        EditorSceneManager.MarkAllScenesDirty();
    }
}
