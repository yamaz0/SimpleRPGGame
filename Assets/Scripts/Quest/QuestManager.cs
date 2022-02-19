using System.Collections;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public InteractQuests InteractQuests { get; }

}

[UnityEditor.CustomEditor(typeof(QuestManager))]
public class QuestManagerEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        var script = (QuestManager)target;
        if (GUILayout.Button($"Refresh", GUILayout.Height(40)))
        {
            script.InteractQuests.UpdateQuestsHandlers();
        }
        base.OnInspectorGUI();
    }
}