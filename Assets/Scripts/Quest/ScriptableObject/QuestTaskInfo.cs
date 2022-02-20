using UnityEngine;

[System.Serializable]
public class QuestTaskInfo
{
    [SerializeField]
    private string title;
    [SerializeField]
    private string desc;
    [SerializeField]
    private int orderNumber;
    [SerializeField]
    private StartQuestEffect effect = new StartQuestEffect();

    public string Title { get => title; set => title = value; }
    public string Desc { get => desc; set => desc = value; }
    public int OrderNumber { get => orderNumber; set => orderNumber = value; }
    public StartQuestEffect Effect { get => effect; set => effect = value; }

    public virtual QuestTask CreateQuestTask()
    {
        return null;
    }
}

[System.Serializable]
public class InteractQuestTaskInfo : QuestTaskInfo
{
    public override QuestTask CreateQuestTask()
    {
        return new InteractQuestTask(this);
    }
}

[System.Serializable]
public class CollectQuestTaskInfo : QuestTaskInfo
{
    [SerializeField]
    [IdDropdown(typeof(ItemsScriptableObject))]
    private int itemId;

    public int ItemId { get => itemId; set => itemId = value; }

    public override QuestTask CreateQuestTask()
    {
        return new CollectQuestTask(this);
    }
}