using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "NPCs", menuName = "ScriptableObjects/NPCs")]
public class NPCScriptableObject : SingletonScriptableObject<NPCScriptableObject>
{
    public NPCInfo GetNPCInfoById(int id)
    {
        foreach (NPCInfo npcInfo in Objects)
        {
            if (npcInfo.Id == id)
            {
                return npcInfo;
            }
        }

        return null;
    }

    public NPCInfo GetNPCInfoByNPC(string name)
    {
        foreach (NPCInfo npcInfo in Objects)
        {
            if (npcInfo.Name == name)
            {
                return npcInfo;
            }
        }

        return null;
    }
}


[UnityEditor.CustomEditor(typeof(NPCScriptableObject))]
public class NpcScriptableObjectEditor : UnityEditor.Editor
{
    List<System.Type> types;
    public NpcScriptableObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(NPCInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(NPCInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (NPCScriptableObject)target;

        foreach (var t in types)
        {
            string[] typeNames = t.ToString().Split('+');
            if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            {
                script.Objects.Add(System.Activator.CreateInstance(t) as NPCInfo);
            }
        }
        base.OnInspectorGUI();
    }
}
