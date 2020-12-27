﻿using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UOP1.StateMachine.Editor
{
	[CustomEditor(typeof(StateSO))]
	public class StateEditor : UnityEditor.Editor
	{
		private ReorderableList _list;
		private SerializedProperty _actions;

		private void OnEnable()
		{
			Undo.undoRedoPerformed += DoUndo;
			_actions = serializedObject.FindProperty("_actions");
			_list = new ReorderableList(serializedObject, _actions, true, true, true, true);
			SetupActionsList(_list);
		}

		private void OnDisable()
		{
			Undo.undoRedoPerformed -= DoUndo;
		}

		public override void OnInspectorGUI()
		{
			_list.DoLayoutList();

			serializedObject.ApplyModifiedProperties();
		}

		private void DoUndo()
		{
			serializedObject.UpdateIfRequiredOrScript();
		}

		private static void SetupActionsList(ReorderableList reorderableList)
		{
			reorderableList.elementHeight *= 1.5f;
			reorderableList.drawHeaderCallback += rect => GUI.Label(rect, "Actions");
			reorderableList.onAddCallback += list =>
			{
				int count = list.count;
				list.serializedProperty.InsertArrayElementAtIndex(count);
				var prop = list.serializedProperty.GetArrayElementAtIndex(count);
				prop.objectReferenceValue = null;
			};

			reorderableList.drawElementCallback += (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				var r = rect;
				r.height = EditorGUIUtility.singleLineHeight;
				r.y += 5;
				r.x += 5;

				var prop = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
				if (prop.objectReferenceValue != null)
				{
					var label = prop.objectReferenceValue.name;
					r.width = 35;
					EditorGUI.PropertyField(r, prop, GUIContent.none);
					r.width = rect.width - 50;
					r.x += 42;
					GUI.Label(r, label, EditorStyles.boldLabel);
				}
				else
					EditorGUI.PropertyField(r, prop, GUIContent.none);
			};

			reorderableList.onChangedCallback += list => list.serializedProperty.serializedObject.ApplyModifiedProperties();
			reorderableList.drawElementBackgroundCallback += (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				if (isFocused)
					EditorGUI.DrawRect(rect, ContentStyle.Focused);

				if (index % 2 != 0)
					EditorGUI.DrawRect(rect, ContentStyle.ZebraDark);
				else
					EditorGUI.DrawRect(rect, ContentStyle.ZebraLight);
			};
		}
	}
}
