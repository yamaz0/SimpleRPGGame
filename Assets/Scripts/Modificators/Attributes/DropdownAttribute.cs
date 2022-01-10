using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class DropdownAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(DropdownAttribute))]
public class DropdownPropertyDrawer : PropertyDrawer
{
    private int selectedIndex = 0;
    private List<string> list = new List<string>();

    protected int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }
    protected List<string> List { get => list; set => list = value; }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (string.IsNullOrEmpty(property.stringValue) || property.stringValue != List[SelectedIndex])
        {
            SelectedIndex = List.FindIndex(x => x.Equals(property.stringValue));
            if (SelectedIndex < 0) SelectedIndex = 0;
        }

        if (List != null && List.Count != 0)
        {
            SelectedIndex = EditorGUI.Popup(position, property.name, SelectedIndex, List.ToArray());
            property.stringValue = List[SelectedIndex];
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
