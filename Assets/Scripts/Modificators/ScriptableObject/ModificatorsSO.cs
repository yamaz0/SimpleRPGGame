using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ModificatorsSO", menuName = "ProjektMagic/ModificatorsSO", order = 0)]
[System.Serializable]
public class ModificatorsSO : ScriptableObject
{
    private static ModificatorsSO instance;
    [SerializeField]
    private List<ModType> modtypes;

    // public List<ModificatorInfo> ModyficatorsInfo { get => modyficatorsInfo; set => modyficatorsInfo = value; }
    public static ModificatorsSO Instance
    {
        get { if (instance == null) LoadInstance(); return instance; }
        set => instance = value;
    }

    public List<ModType> Modtypes { get => modtypes; set => modtypes = value; }

    private void OnEnable()
    {
        if (Instance == null)
            LoadInstance();
        // FillModifiersList();
    }

    private static void LoadInstance()
    {
        instance = Resources.LoadAll<ModificatorsSO>("")[0];
    }

    public static string GetClassDetails(Type t, ref string searchPropertyName, string str = null)
    {
        foreach (var propertyInfo in t.GetProperties())
        {
            if (propertyInfo.Name.Equals(searchPropertyName))
            {
                searchPropertyName = string.Empty;
                return searchPropertyName;
            }

            if (string.IsNullOrEmpty(str) == true)
                str = propertyInfo.Name;
            else
                str = $"{str}.{propertyInfo.Name}";

            if (propertyInfo.PropertyType.IsClass)
            {
                string v = GetClassDetails(propertyInfo.PropertyType, ref searchPropertyName, str);
                if (string.IsNullOrEmpty(v) == false)
                    str = $"{str}.{v}";

            }
            if (string.IsNullOrEmpty(searchPropertyName)) break;
            str = "";
        }

        return str;
    }

    public void FillModifiersList()
    {
        System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        Modtypes.Clear();

        foreach (var assembly in assemblies)
        {
            foreach (Type t in assembly.GetTypes())
            {
                if (t.IsDefined(typeof(ModificatorTypeAttribute)))
                {
                    ModType mt = new ModType();

                    // Debug.Log(t.Name);
                    var x = t.GetProperties().Where(prop => System.Attribute.IsDefined(prop, typeof(ModificatorAttribute)));
                    mt.ModTypeName = t.Name;

                    foreach (var p in x)
                    {
                        mt.ModNames.Add(p.Name);
                        // Debug.Log(p.Name);
                    }

                    Modtypes.Add(mt);
                }
            }
        }
    }

    public static Modificator GetModifier(Character c, ModificatorInfo info)
    {
        PropertyInfo property;
        if (string.IsNullOrEmpty(info.NestesPropertyClassName) == true)
        {
            property = c.GetType().GetProperty(info.PropertyName, BindingFlags.Public | BindingFlags.Instance);
            return (Modificator)property.GetValue(c);
        }
        else
        {
            object nestedObject = c.GetType().GetProperty(info.NestesPropertyClassName).GetValue(c);
            property = nestedObject.GetType().GetProperty(info.PropertyName, BindingFlags.Public | BindingFlags.Instance);
            return (Modificator)property.GetValue(nestedObject);
        }
    }

    // public List<string> GetModificatorsNamesList()
    // {
    //     List<string> list = new List<string>();

    //     foreach (ModificatorInfo info in ModyficatorsInfo)
    //     {
    //         list.Add(info.PropertyName);
    //     }

    //     return list;
    // }
    [System.Serializable]
    public class ModType
    {
        [SerializeField]
        private string modTypeName;
        [SerializeField]
        private List<string> modNames = new List<string>();

        public string ModTypeName { get => modTypeName; set => modTypeName = value; }
        public List<string> ModNames { get => modNames; set => modNames = value; }
    }

}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ModificatorAttribute : System.Attribute
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ModificatorTypeAttribute : System.Attribute
{
}

#if UNITY_EDITOR
[CustomEditor(typeof(ModificatorsSO))]
public class ModificatorsSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (ModificatorsSO)target;

        if (GUILayout.Button("Refresh", GUILayout.Height(40)))
        {
            script.FillModifiersList();
            UnityEditor.EditorUtility.SetDirty(script);
            AssetDatabase.SaveAssets();
        }
    }
}
#endif