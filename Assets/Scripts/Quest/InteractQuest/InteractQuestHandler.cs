using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractQuestHandler
{
    [SerializeField]
    [IdDropdown(typeof(QuestScriptableObject))]
    private int questId;
    [SerializeField]
    private List<InteractQuestTaskHandler> questTasks = new List<InteractQuestTaskHandler>();

    public int QuestId { get => questId; set => questId = value; }
    public List<InteractQuestTaskHandler> QuestTasks { get => questTasks; set => questTasks = value; }

    public InteractQuestHandler(int id)
    {
        QuestId = id;
        QuestTasks = new List<InteractQuestTaskHandler>(1);
        // QuestTasks.Add(new InteractQuestTaskHandler());
    }

    public void AddTaskEffectsToInteractObject(InteractQuestTaskInfo task)
    {
        for (int i = 0; i < QuestTasks.Count; i++)
        {
            if (QuestTasks[i].TaskIndex == task.OrderNumber)
            {
                QuestTasks[i].InteractActionEffectAdd(task);
                break;
            }
        }
    }
}
