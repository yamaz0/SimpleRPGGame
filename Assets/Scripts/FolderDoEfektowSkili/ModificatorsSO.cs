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
    private List<ModificatorInfo> modyficatorsInfo;

    public List<ModificatorInfo> ModyficatorsInfo { get => modyficatorsInfo; set => modyficatorsInfo = value; }
    public static ModificatorsSO Instance { get => instance; set => instance = value; }

    private void OnEnable()
    {
        Instance = Resources.LoadAll<ModificatorsSO>("")[0];
        // FillModifiersList();
    }

    public static string GetClassDetails(Type t,ref string searchPropertyName, string str = null )
    {
        foreach (var propertyInfo in t.GetProperties())
        {
            if(propertyInfo.Name.Equals(searchPropertyName))
            {
                searchPropertyName = string.Empty;
                return searchPropertyName;
            }

            if(string.IsNullOrEmpty(str) == true)
                str = propertyInfo.Name;
            else
                str = $"{str}.{propertyInfo.Name}";

            if (propertyInfo.PropertyType.IsClass)
            {
                string v = GetClassDetails(propertyInfo.PropertyType, ref searchPropertyName, str);
                if(string.IsNullOrEmpty(v) == false)
                    str = $"{str}.{v}";

            }
            if(string.IsNullOrEmpty(searchPropertyName)) break;
            str = "";
        }

        return str;
    }

    public void FillModifiersList()
    {
        System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        ModyficatorsInfo.Clear();

        foreach (var assembly in assemblies)
        {
            foreach (Type t in assembly.GetTypes())
            {
                IEnumerable<System.Reflection.PropertyInfo> props = t.GetProperties().Where( prop => System.Attribute.IsDefined(prop, typeof(ModificatorAttribute)));
                foreach (var p in props.ToList())
                {
                    Debug.Log(p.Name);
                    string tmpName = p.Name;
                    string nestedPropertyName = GetClassDetails(typeof(Character), ref tmpName);
                    ModificatorInfo modificatorInfo = new ModificatorInfo();
                    modificatorInfo.Init(p.Name, nestedPropertyName);

                    ModyficatorsInfo.Add(modificatorInfo);
                }
            }
        }
    }

    public static Modificator GetModifier(Character c, ModificatorInfo info)
    {
        PropertyInfo property;
        if(string.IsNullOrEmpty(info.NestesPropertyClassName) == true)
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

    public List<string> GetModificatorsNamesList()
    {
        List<string> list = new List<string>();

        foreach (ModificatorInfo info in ModyficatorsInfo)
        {
            list.Add(info.PropertyName);
        }

        return list;
    }


}


[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ModificatorAttribute : System.Attribute
{
    // See the attribute guidelines at
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    // readonly string positionalString;

    // This is a positional argument
    public ModificatorAttribute()
    {
        // this.positionalString = positionalString;
    }

    // public string PositionalString
    // {
    //     get { return positionalString; }
    // }
}
 [CustomEditor(typeof(ModificatorsSO))]
 public class ModificatorsSOEditor : Editor
 {
    public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (ModificatorsSO)target;

                if(GUILayout.Button("Refresh", GUILayout.Height(40)))
                {
                    script.FillModifiersList();
                    UnityEditor.EditorUtility.SetDirty(script);
                    AssetDatabase.SaveAssets();
                }
        }
 }