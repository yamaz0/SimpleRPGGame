using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class AbilitiesDropdownAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(AbilitiesDropdownAttribute))]
public class AbilitiesDropdownPropertyDrawer : DropdownPropertyDrawer
{
    public void Init()
    {
        List.Clear();
        foreach (var ability in AbilityScriptableObject.Instance.Abilities)
        {
            List.Add(ability.Name);
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (List == null || List.Count == 0) Init();

        AbilityInfo abilityInfo = AbilityScriptableObject.Instance.GetAbilityInfoById(property.intValue);

        if (abilityInfo != null && abilityInfo.Name != List[SelectedIndex])
        {
            SelectedIndex = List.FindIndex(x => x.Equals(abilityInfo.Name));
            if (SelectedIndex < 0) SelectedIndex = 0;
        }

        if (List != null && List.Count != 0)
        {
            SelectedIndex = EditorGUI.Popup(position, property.name, SelectedIndex, List.ToArray());
            property.intValue = AbilityScriptableObject.Instance.GetAbilityInfoByName(List[SelectedIndex]).Id;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}