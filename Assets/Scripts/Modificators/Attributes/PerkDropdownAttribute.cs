using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class PerkDropdownAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(PerkDropdownAttribute))]
public class PerkDropdownPropertyDrawer : DropdownPropertyDrawer
{
    public void Init()
    {
        List.Clear();
        foreach (var perk in PerkScriptableObject.Instance.Perks)
        {
            List.Add(perk.Name);
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (List == null || List.Count == 0) Init();

        PerkScriptableObject.PerkInfo perkInfo = PerkScriptableObject.Instance.GetPerkInfoById(property.intValue);

        if (perkInfo != null && perkInfo.Name != List[SelectedIndex])
        {
            SelectedIndex = List.FindIndex(x => x.Equals(perkInfo.Name));
            if (SelectedIndex < 0) SelectedIndex = 0;
        }

        if (List != null && List.Count != 0)
        {
            SelectedIndex = EditorGUI.Popup(position, property.name, SelectedIndex, List.ToArray());
            property.intValue = PerkScriptableObject.Instance.GetPerkInfoByName(List[SelectedIndex]).Id;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}