using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SideQuestStatus
{
    [SerializeField]
    private int questId;
    [SerializeField]
    private int actualTaskNumber;

    public int QuestId { get => questId; set => questId = value; }
    public int ActualTaskNumber { get => actualTaskNumber; set => actualTaskNumber = value; }

    public SideQuestStatus(int sideQuestId)
    {
        QuestId = sideQuestId;
    }
}

[System.Serializable]
public class PlayerQuestController
{
    [SerializeField]
    private List<int> doneSideQuestsId = new List<int>();
    [SerializeField]
    private List<SideQuestStatus> actualSideQuestsId = new List<SideQuestStatus>();
    [SerializeField]
    private int actualMainQuestId;

    public List<int> DoneSideQuestsId { get => doneSideQuestsId; private set => doneSideQuestsId = value; }
    public List<SideQuestStatus> ActualSideQuestsId { get => actualSideQuestsId; private set => actualSideQuestsId = value; }
    public int ActualMainQuestId { get => actualMainQuestId; private set => actualMainQuestId = value; }
    // public Quest Quests { get; set; }

    public event System.Action<int> OnActualMainQuestIdChanged;
    public event System.Action<int> OnActualSideQuestsIdChanged;
    public event System.Action<int> OnDoneSideQuestsIdChanged;

    private void DoneSideQuest(int sideQuestId)
    {
        RemoveSideQuest(sideQuestId);
        OnActualSideQuestsIdChanged(sideQuestId);
        AddDoneSideQuestsId(sideQuestId);
    }

    public void UpdateSideQuest(int sideQuestId)
    {
        for (int i = 0; i < ActualSideQuestsId.Count; i++)
        {
            if (ActualSideQuestsId[i].QuestId == sideQuestId)
            {
                ActualSideQuestsId[i].ActualTaskNumber++;
                SideQuestInfo sideQuestInfo = QuestScriptableObject.Instance.Objects.GetElementById(sideQuestId) as SideQuestInfo;

                if (ActualSideQuestsId[i].ActualTaskNumber >= sideQuestInfo.Tasks.Count)
                {
                    DoneSideQuest(sideQuestId);
                }
            }
        }
    }

    private void RemoveSideQuest(int sideQuestId)
    {
        for (int i = 0; i < ActualSideQuestsId.Count; i++)
        {
            if (ActualSideQuestsId[i].QuestId == sideQuestId)
            {
                ActualSideQuestsId.RemoveAt(i);
                break;
            }
        }
    }

    public void UpdateMainQuestId(int questId)
    {
        ActualMainQuestId = questId;
        OnActualMainQuestIdChanged(questId);
    }

    public void AddActualSideQuestsId(int questId)
    {
        ActualSideQuestsId.Add(new SideQuestStatus(questId));
        OnActualSideQuestsIdChanged(questId);
    }

    public void RemoveSideQuestsId(int questId)
    {
        RemoveSideQuest(questId);
        OnActualSideQuestsIdChanged(questId);
        //quest niepowodzenie
    }

    public void AddDoneSideQuestsId(int questId)
    {
        DoneSideQuestsId.Add(questId);
        OnDoneSideQuestsIdChanged(questId);
    }
    public bool HasDoneSideQuest(int sideQuestId)
    {
        return DoneSideQuestsId.Contains(sideQuestId);
    }

    public bool IsSideQuestStarted(int sideQuestId)
    {
        for (int i = 0; i < ActualSideQuestsId.Count; i++)
        {
            if (ActualSideQuestsId[i].QuestId == sideQuestId)
            {
                return true;
            }
        }
        return false;
    }
}
