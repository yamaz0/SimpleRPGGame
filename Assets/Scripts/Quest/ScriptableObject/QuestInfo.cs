using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;

    [SerializeReference]
    List<QuestTaskInfo> tasks = new List<QuestTaskInfo>();

    public List<QuestTaskInfo> Tasks { get => tasks; set => tasks = value; }

    public QuestTask GetQuestTask(int orderNumber)
    {
        for (int i = 0; i < Tasks.Count; i++)
        {
            if (Tasks[i].OrderNumber == orderNumber)
                return Tasks[i].CreateQuestTask();
        }

        return null;
    }
}
