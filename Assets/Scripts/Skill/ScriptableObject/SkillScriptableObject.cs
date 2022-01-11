using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillObject", menuName = "ScriptableObjects/SkillObject")]
public class SkillScriptableObject : ScriptableObject
{
    // [SerializeField]
    // private Text skillnameText;
    // [SerializeField]
    // private Text effectnameText;

    [SerializeField]
    private Skill skill;

    public Skill Skill { get => skill; set => skill = value; }
}
[UnityEditor.CustomEditor(typeof(SkillScriptableObject))]
public class SkillObjectEditor : UnityEditor.Editor
{
    List<System.Type> types;
    bool showPosition;
    public SkillObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(OneCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(OneCharacterEffect))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (SkillScriptableObject)target;
        showPosition = UnityEditor.EditorGUILayout.Foldout(showPosition, "Add effects buttons");
        if (showPosition)
        {
            foreach (var t in types)
            {
                if (GUILayout.Button($"{t.ToString()}", GUILayout.Height(40)))
                {
                    OneCharacterEffect e = System.Activator.CreateInstance(t) as OneCharacterEffect;
                    e.Name = t.ToString();
                    script.Skill.AddEffect(e);
                }
            }
        }
        base.OnInspectorGUI();
    }
}
