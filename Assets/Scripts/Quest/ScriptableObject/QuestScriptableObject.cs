using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "ScriptableObjects/Quests")]
public class QuestScriptableObject : SingletonScriptableObject<QuestScriptableObject>
{
    public List<QuestInfo> GetQuestInfoList()
    {
        List<QuestInfo> questInfos = new List<QuestInfo>(Objects.Count);

        foreach (QuestInfo questInfo in Objects)
        {
            questInfos.Add(questInfo);
        }

        return questInfos;
    }

    public QuestInfo GetQuestInfoById(int id)
    {
        foreach (QuestInfo questInfo in Objects)
        {
            if (questInfo.Id == id)
            {
                return questInfo;
            }
        }

        return null;
    }

    public QuestInfo GetQuestInfoByQuest(string name)
    {
        foreach (QuestInfo questInfo in Objects)
        {
            if (questInfo.Name == name)
            {
                return questInfo;
            }
        }

        return null;
    }
}

[UnityEditor.CustomEditor(typeof(QuestScriptableObject))]
public class QuestScriptableObjectEditor : UnityEditor.Editor
{
    List<System.Type> types;
    public QuestScriptableObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(QuestInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(QuestInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (QuestScriptableObject)target;

        foreach (var t in types)
        {
            string[] typeNames = t.ToString().Split('+');
            if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            {
                script.Objects.Add(System.Activator.CreateInstance(t) as QuestInfo);
            }
        }
        base.OnInspectorGUI();
    }
}