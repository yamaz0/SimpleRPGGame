using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkObject", menuName = "ScriptableObjects/PerkObject")]
public class PerkScriptableObject : ScriptableObject
{
    // [SerializeField]
    // private Text skillnameText;
    // [SerializeField]
    // private Text effectnameText;

    [SerializeField]
    private Perk perk;

    public Perk Perk { get => perk; set => perk = value; }
}
[UnityEditor.CustomEditor(typeof(PerkScriptableObject))]
public class PerkObjectEditor : UnityEditor.Editor
{
    List<System.Type> types;
    bool showPosition;
    public PerkObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(OneCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(OneCharacterEffect))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (PerkScriptableObject)target;
        showPosition = UnityEditor.EditorGUILayout.Foldout(showPosition, "Add effects buttons");
        if (showPosition)
        {
            foreach (var t in types)
            {
                if (GUILayout.Button($"{t.ToString()}", GUILayout.Height(40)))
                {
                    OneCharacterEffect e = System.Activator.CreateInstance(t) as OneCharacterEffect;
                    e.Name = t.ToString();
                    script.Perk.AddEffect(e);
                }
            }
        }
        base.OnInspectorGUI();
    }
}
