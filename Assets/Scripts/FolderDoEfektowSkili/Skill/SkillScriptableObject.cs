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
    public SkillObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(Effect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(Effect))).ToList();
    }
    public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (SkillScriptableObject)target;

            foreach (var t in types)
            {
                if(GUILayout.Button($"Add {t.ToString()}", GUILayout.Height(40)))
                {
                    script.Skill.AddEffect(System.Activator.CreateInstance(t) as Effect);
                }
            }
        }
 }
