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
    // private void OnValidate() {
    //     SideQuestInfo qi = new SideQuestInfo();
    //     qi.Tasks.Add(new InteractQuestTask());
    //     Objects.Add(qi);
    // }
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
    public override void OnInspectorGUI()
    {
        var script = (QuestScriptableObject)target;
        if (GUILayout.Button($"Add", GUILayout.Height(40)))
        {
            script.Objects.Add(new QuestInfo());
        }
        base.OnInspectorGUI();
    }
}