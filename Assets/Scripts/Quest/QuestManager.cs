using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    private QuestScriptableObject questSO;

    [SerializeField]
    private List<InteractQuestTaskHandler> quests;

    public void InitQuestTask(QuestInfo questInfo)
    {
        for (int i = 0; i < quests.Count; i++)
        {
            // if(quests[i].QuestId == questInfo.Id && questInfo.OrderNumber == quests[i].TaskIndex)
            // {
            //     quests[i].InteractActionEffectAdd();
            // }
        }
    }
}

[System.Serializable]
public class InteractQuestTaskHandler
{
    [SerializeField]
    [IdDropdown(typeof(QuestScriptableObject))]
    private int questId;
    [SerializeField]
    private int taskIndex = 0;
    [SerializeField]
    private InteractObject interactObject;

    public int QuestId { get => questId; set => questId = value; }
    public int TaskIndex { get => taskIndex; set => taskIndex = value; }
    public InteractObject InteractObject { get => interactObject; set => interactObject = value; }

    public void InteractActionEffectAdd(OneCharacterEffect e)
    {
        InteractObject.Efects.Add(e);
    }

}