using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// ModificatorsNamesSO
[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class ModDropdownAttribute : PropertyAttribute
{
    private string modtype;
    public string Modtype { get => modtype; set => modtype = value; }

    public ModDropdownAttribute(string name)
    {
        Modtype = name;
    }
}

[CustomPropertyDrawer(typeof(ModDropdownAttribute))]
public class ModDropdownPropertyDrawer : DropdownPropertyDrawer
{
    public void Init()
    {
        ModDropdownAttribute atb = attribute as ModDropdownAttribute;
        ModificatorsSO.ModType modType = ModificatorsSO.Instance.Modtypes.Find(x => x.ModTypeName.Equals(atb.Modtype));
        List.Clear();
        List.AddRange(modType.ModNames);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if(List == null || List.Count == 0) Init();
        base.OnGUI(position, property, label);
    }
}
