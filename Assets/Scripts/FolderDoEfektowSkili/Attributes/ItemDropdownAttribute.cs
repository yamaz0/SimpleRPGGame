using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// ModificatorsNamesSO
[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class ItemDropdownAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(ItemDropdownAttribute))]
public class ItemDropdownPropertyDrawer : DropdownPropertyDrawer
{
    public void Init()
    {
        ItemDropdownAttribute atb = attribute as ItemDropdownAttribute;
        List.Clear();
        foreach (var item in ItemsScriptableObject.Instance.Items)
        {
            List.Add(item.Name);
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (List == null || List.Count == 0) Init();

        ItemInfo itemInfo = ItemsScriptableObject.Instance.GetItemInfoById(property.intValue);

        if (itemInfo == null || itemInfo.Name != List[SelectedIndex])
        {
            SelectedIndex = List.FindIndex(x => x.Equals(itemInfo.Name));
            if (SelectedIndex < 0) SelectedIndex = 0;
        }

        if (List != null && List.Count != 0)
        {
            SelectedIndex = EditorGUI.Popup(position, property.name, SelectedIndex, List.ToArray());
            property.intValue = ItemsScriptableObject.Instance.GetItemInfoByName(List[SelectedIndex]).Id;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
