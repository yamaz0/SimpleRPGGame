public class InteractQuestTask : QuestTask
{
    public InteractObject InteractObjectCache{get;set;}

    public override void Init(int questId)
    {
        QuestManager.Instance.InteractQuests.InitQuestTask(questId, this);
    }

    public override void End(int questId)
    {
        InteractObjectCache.Efects.Remove(questInfo.Effect);
    }

    // public void Init(InteractObject interactGameObject)
    // {
    //     interactGameObject.Efects.Add(Effect);
    // }
    public InteractQuestTask(QuestTaskInfo info) : base(info)
    {
    }
}

