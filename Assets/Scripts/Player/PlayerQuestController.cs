using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskQuestStatus
{
    [SerializeField]
    private int questId;
    [SerializeField]
    private int taskNumber;

    public int QuestId { get => questId; set => questId = value; }
    public int TaskNumber { get => taskNumber; set => taskNumber = value; }

    public TaskQuestStatus(int sideQuestId, int taskOrderNumber)
    {
        QuestId = sideQuestId;
        TaskNumber = taskOrderNumber;
    }
}

[System.Serializable]
public class PlayerQuestController//TODO PRZEROBIC CALY QUEST SYSTEM
{
    [SerializeField]
    private List<int> doneQuestsId = new List<int>();
    [SerializeField]
    private List<int> actualQuestsId = new List<int>();
    [SerializeField]
    private List<int> cancelQuestsId = new List<int>();
    [SerializeField]
    private List<int> pendingQuestsId = new List<int>();
    [SerializeField]
    private List<int> avaibleQuestsId = new List<int>();

    public List<int> DoneQuestsId { get => doneQuestsId; private set => doneQuestsId = value; }
    public List<int> ActualQuestsId { get => actualQuestsId; private set => actualQuestsId = value; }
    public List<int> CancelQuestsId { get => cancelQuestsId; private set => cancelQuestsId = value; }
    public List<int> PendingQuestsId { get => pendingQuestsId; private set => pendingQuestsId = value; }
    public List<int> AvaibleQuestsId { get => avaibleQuestsId; private set => avaibleQuestsId = value; }
    public List<Quest> Quests { get; set; } // tu trzeba sie bardziej zastanowic nad questami

    public event System.Action<int> OnActualQuestsIdChanged = delegate { };
    public event System.Action<int> OnDoneSideQuestsIdChanged = delegate { };

    public void Init()
    {
        Quests = new List<Quest>(ActualQuestsId.Count);
        for (int i = 0; i < ActualQuestsId.Count; i++)
        {
            QuestInfo questInfo = QuestScriptableObject.Instance.GetQuestInfoById(ActualQuestsId[i]);
            Quests.Add(new Quest(questInfo));
        }
    }

    private void DoneQuest(int questId)
    {
        OnActualQuestsIdChanged(questId);
        RemoveActualQuest(questId);
        AddDoneQuestId(questId);
    }

    public void UpdateQuest(int questId)
    {
        bool isQuestExist = false;

        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].QuestInfo.Id == questId)
            {
                isQuestExist = true;
                Quests[i].UpdateQuest();

                if (Quests[i].CurrentTaskNumber >= Quests[i].QuestInfo.Tasks.Count)
                {
                    DoneQuest(questId);
                }
                break;
            }
        }

        if (isQuestExist == false)
        {
            QuestInfo questInfo = QuestScriptableObject.Instance.GetQuestInfoById(questId);
            Quest newQuest = new Quest(questInfo);
            Quests.Add(newQuest);
            ActualQuestsId.Add(questId);
        }
    }

    private void RemoveActualQuest(int questId)
    {
        for (int i = 0; i < ActualQuestsId.Count; i++)
        {
            if (ActualQuestsId[i] == questId)
            {
                ActualQuestsId.RemoveAt(i);
                Quests.RemoveAt(i);
                break;
            }
        }
    }

    public void RemoveActualQuestById(int questId)
    {
        RemoveActualQuest(questId);
        OnActualQuestsIdChanged(questId);
        //quest niepowodzenie
    }

    private void AddDoneQuestId(int questId)
    {
        DoneQuestsId.Add(questId);
        OnDoneSideQuestsIdChanged(questId);
    }
    public bool HasDoneQuest(int sideQuestId)
    {
        return DoneQuestsId.Contains(sideQuestId);
    }

    public bool IsQuestStarted(int sideQuestId)
    {
        for (int i = 0; i < ActualQuestsId.Count; i++)
        {
            if (ActualQuestsId[i] == sideQuestId)
            {
                return true;
            }
        }
        return false;
    }
}
