using System.Collections;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    private InteractQuests interactQuests = new InteractQuests();

    public InteractQuests InteractQuests { get => interactQuests; set => interactQuests = value; }

    public void QuestUpdate(int id)
    {
        Player.Instance.PlayerQuestController.UpdateQuest(id);
    }

    public void QuestRemove(int id)
    {
        Player.Instance.PlayerQuestController.RemoveActualQuestById(id);
    }
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