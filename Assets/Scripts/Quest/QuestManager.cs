using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    private List<InteractQuestHandler> quests = new List<InteractQuestHandler>();

    public void InitQuestTask(int questId, InteractQuestTask questTask)
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].QuestId == questId)
            {
                quests[i].AddTaskEffectsToInteractObject(questTask);
                break;
            }
        }
    }

    private void OnValidate()
    {
        // UpdateQuestsHandlers();
    }

    public void UpdateQuestsHandlers()//moga pojawiac sie duplikaty DO POPRAWY
    {
        List<QuestInfo> questInfos = QuestScriptableObject.Instance.GetQuestInfoList();

        for (int i = quests.Count - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if(quests[i].QuestId == quests[j].QuestId)
                {
                    quests.RemoveAt(i);
                    break;
                }
            }
        }

        RemoveWrongData(questInfos);

        for (int i = 0; i < questInfos.Count; i++)
        {
            TryAddInteractQuest(questInfos[i]);
        }
    }

    private void RemoveWrongData(List<QuestInfo> questInfos)
    {
        for (int i = quests.Count - 1; i >= 0; i--)
        {
            bool isQuestExist = false;
            for (int j = 0; j < questInfos.Count; j++)
            {
                if (quests[i].QuestId == questInfos[j].Id)
                {
                    isQuestExist = true;
                    bool isTaskExist = false;
                    for (int k = quests[i].QuestTasks.Count - 1; k >= 0; k--)
                    {
                        isTaskExist = false;
                        for (int l = 0; l < questInfos[j].Tasks.Count; l++)
                        {
                            if (questInfos[j].Tasks[l] is InteractQuestTask task && task.OrderNumber == quests[i].QuestTasks[k].TaskIndex)
                            {
                                isTaskExist = true;
                                break;
                            }
                        }
                        if (isTaskExist == false)
                        {
                            quests[i].QuestTasks.RemoveAt(k);
                        }
                    }
                    break;
                }

            }
            if (isQuestExist == false)
            {
                quests.RemoveAt(i);
            }
        }
    }

    private void TryAddInteractQuest(QuestInfo questInfo)
    {
        bool isQuestExist = false;
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].QuestId == questInfo.Id)
            {
                isQuestExist = true;
                TryAddQuestTasks(quests[i], questInfo);
                break;
            }
        }
        if (isQuestExist == false)
        {
            AddInteractQuestHandler(questInfo);
        }
    }
    private void AddInteractQuestHandler(QuestInfo questInfo)
    {
        for (int i = 0; i < questInfo.Tasks.Count; i++)
        {
            if (questInfo.Tasks[i] is InteractQuestTask interactQuestTask)
            {
                InteractQuestHandler quest = new InteractQuestHandler(questInfo.Id);

                quests.Add(quest);
                TryAddQuestTasks(quest, questInfo);
                break;
            }
        }
    }

    private void TryAddQuestTasks(InteractQuestHandler quest, QuestInfo questInfo)
    {
        for (int i = 0; i < questInfo.Tasks.Count; i++)
        {
            if (questInfo.Tasks[i] is InteractQuestTask interactQuestTask)
            {
                bool isQuestTaskExist = false;
                for (int j = 0; j < quest.QuestTasks.Count; j++)
                {
                    if (quest.QuestTasks[j].TaskIndex == interactQuestTask.OrderNumber)
                    {
                        isQuestTaskExist = true;
                        break;
                    }
                }
                if (isQuestTaskExist == false)
                {
                    quest.QuestTasks.Add(new InteractQuestTaskHandler(interactQuestTask.OrderNumber));
                }
            }
        }
    }
}

[System.Serializable]
public class InteractQuestHandler
{
    [SerializeField]
    [IdDropdown(typeof(QuestScriptableObject))]
    private int questId;
    [SerializeField]
    private List<InteractQuestTaskHandler> questTasks;

    public int QuestId { get => questId; set => questId = value; }
    public List<InteractQuestTaskHandler> QuestTasks { get => questTasks; set => questTasks = value; }

    public InteractQuestHandler(int id)
    {
        QuestId = id;
        QuestTasks = new List<InteractQuestTaskHandler>(1);
        // QuestTasks.Add(new InteractQuestTaskHandler());
    }

    public void AddTaskEffectsToInteractObject(InteractQuestTask task)
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

[System.Serializable]
public class InteractQuestTaskHandler
{
    [SerializeField]
    private int taskIndex = 0;
    [SerializeField]
    private InteractObject interactObject;

    public int TaskIndex { get => taskIndex; set => taskIndex = value; }
    public InteractObject InteractObject { get => interactObject; set => interactObject = value; }

    public InteractQuestTaskHandler(int index = 0)
    {
        taskIndex = index;
    }

    public void InteractActionEffectAdd(InteractQuestTask task)
    {
        task.Init(InteractObject);
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
            script.UpdateQuestsHandlers();
        }
        base.OnInspectorGUI();
    }
}