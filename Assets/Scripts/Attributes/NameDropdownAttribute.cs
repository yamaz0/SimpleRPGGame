using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class NameDropdownAttribute : PropertyAttribute
{
    private string modtype;
    public string Modtype { get => modtype; set => modtype = value; }

    public NameDropdownAttribute(string name)
    {
        Modtype = name;
    }
}

[CustomPropertyDrawer(typeof(NameDropdownAttribute))]
public class NameDropdownPropertyDrawer : PropertyDrawer
{
    private int SelectedIndex { get; set; }
    private List<string> List { get; set; }

    public void Init()
    {
        NameDropdownAttribute atb = attribute as NameDropdownAttribute;
        ModificatorsSO.ModType modType = ModificatorsSO.Instance.Modtypes.Find(x => x.ModTypeName.Equals(atb.Modtype));
        List = new List<string>();

        List.Clear();
        List.AddRange(modType.ModNames);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (List == null || List.Count == 0) Init();
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
