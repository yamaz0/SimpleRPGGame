using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "SpellsEffect", menuName = "ScriptableObjects/SpellsEffect")]
public class SpellsEffectScriptableObject: ScriptableObject
{
    private static SpellsEffectScriptableObject instance;

    [SerializeField]
    private List<SpellEffectInfo> spells;

    public static SpellsEffectScriptableObject Instance { get { return instance; } }

    public List<SpellEffectInfo> Spells { get => spells; set => spells = value; }

    // [RuntimeInitializeOnLoadMethod]
    // private static void Init()
    // {
    //     instance = Resources.LoadAll<SpellsEffectScriptableObject>("")[0];
    // }

    public SpellsEffectScriptableObject()
    {
        instance = this;
    }
    private void OnEnable()
    {
        Spells.Clear();
        Spells.AddRange(Resources.LoadAll<SpellEffectInfo>(""));
    }

    public SpellEffectInfo GetSpellInfoById(int id)
    {
        foreach (SpellEffectInfo nameInfo in Spells)
        {
            if (nameInfo.Id == id)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public SpellEffectInfo GetSpellInfoByName(string name)
    {
        foreach (SpellEffectInfo nameInfo in Spells)
        {
            if (nameInfo.EffectName == name)
            {
                return nameInfo;
            }
        }

        return null;
    }
}

// [CustomEditor(typeof(SpellsEffectScriptableObject))]
//  public class SpellsEffectScriptableObjectEditor : Editor
//  {
//     private List<System.Type> typeList;
//     private string[] texts = {"Empty"};
//     private int selectedIndex = 0;

//     public SpellsEffectScriptableObjectEditor()
//     {
//         Assembly asmbly = Assembly.GetExecutingAssembly();
//         typeList = asmbly.GetTypes().Where(
//                 t => t.GetCustomAttributes(typeof (Effect), true).Length > 0
//         ).ToList();

//         foreach (var t in typeList)
//         {
//             Debug.Log(t.ToString());
//         }

//         texts = typeList.Select(i => i.ToString()).ToArray();
//     }

//     public override void OnInspectorGUI()
//     {
//         base.DrawDefaultInspector();

//          SpellsEffectScriptableObject gd = (SpellsEffectScriptableObject)target;
//         //  EditorGUILayout.IntField ("Layout number", gd.Spells);
//         // EditorGUI.DropdownButton

//         selectedIndex = EditorGUILayout.Popup("Effects", selectedIndex, texts);

//         if (GUILayout.Button("ADD"))
//         {
//             Debug.Log(texts[selectedIndex]);
//             if(typeList[selectedIndex] == typeof(DamageMirrorEffect))
//             {
//                 // gd.Spells.Add(new SpellsEffectScriptableObject.SpellEffectInfo2("SpellEffectInfo2"));
//             }
//             else if(typeList[selectedIndex] == typeof(DamageMirrorEffect1))
//             {

//                 // gd.Spells.Add(new SpellsEffectScriptableObject.SpellEffectInfo3("SpellEffectInfo3"));
//             }
//         }
//         //  if(GUI.changed)
//         //      EditorUtility.SetDirty(target);
//      }
//  }