using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class IdDropdownAttribute : PropertyAttribute
{
    List<BaseInfo> objects = new List<BaseInfo>();
    public List<BaseInfo> Objects { get => objects; set => objects = value; }

    public IdDropdownAttribute(Type t)
    {
        Type at = typeof(SingletonScriptableObject<>).MakeGenericType(t);
        System.Reflection.PropertyInfo propertyInfo = at.GetProperty("Instance", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy);
        object v = propertyInfo.GetValue(null);

        List<BaseInfo> searchables = (List<BaseInfo>)t.GetProperty("Objects").GetValue(v);

        Objects.AddRange(searchables);
    }
}

[CustomPropertyDrawer(typeof(IdDropdownAttribute))]
public class IdDropdownPropertyDrawer : PropertyDrawer
{
    private int selectedIndex = 0;
    private List<string> names = new List<string>();

    protected int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }
    protected List<string> Names { get => names; set => names = value; }

    private bool ShowField { get; set; }


    IdDropdownAttribute atb;
    public void Init()
    {
        atb = attribute as IdDropdownAttribute;

        Names.Clear();
        foreach (var obj in atb.Objects)
        {
            Names.Add(obj.Name);
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (Names == null || Names.Count == 0) Init();

        Rect foldoutPosition = new Rect(position.x - 15, position.y, 30, position.height);
        ShowField = EditorGUI.Toggle(foldoutPosition,new GUIContent("", "Dropdown/Field"), ShowField);
        BaseInfo objInfo = atb.Objects.GetElementById(property.intValue);

        if (objInfo != null && objInfo.Name != Names[SelectedIndex])
        {
            SelectedIndex = Names.FindIndex(x => x.Equals(objInfo.Name));
            if (SelectedIndex < 0) SelectedIndex = 0;
        }

        if (ShowField == true && Names != null && Names.Count != 0)
        {
            SelectedIndex = EditorGUI.Popup(position, property.name, SelectedIndex, Names.ToArray());
            property.intValue = atb.Objects.GetElementByName(Names[SelectedIndex]).Id;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}