using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// ModificatorsNamesSO
[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
sealed class ModDropdownAttribute : PropertyAttribute
{
    public ModDropdownAttribute() { }
}

[CustomPropertyDrawer(typeof(ModDropdownAttribute))]
public class DropdownPropertyDrawer : PropertyDrawer
{
    private int selectedIndex = 0;
    private List<string> list;

    public DropdownPropertyDrawer()
    {
        list = ModificatorsNamesSO.instance.Names;
        if(ModificatorsNamesSO.instance.Names.Count == 0) ModificatorsNamesSO.instance.Init();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (string.IsNullOrEmpty(property.stringValue) || property.stringValue != list[selectedIndex])
        {
            selectedIndex = list.FindIndex(x => x.Equals(property.stringValue));
            if (selectedIndex < 0) selectedIndex = 0;
        }

        if (list != null && list.Count != 0)
        {
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, list.ToArray());
            property.stringValue = list[selectedIndex];
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
