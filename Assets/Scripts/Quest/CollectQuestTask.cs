public class CollectQuestTask : QuestTask
{
    public CollectQuestTask(QuestTaskInfo info) : base(info)
    {
    }

    public override void Init(int questId)
    {
        bool hasItem = Player.Instance.Character.InventoryController.Inventory.ItemsId.Contains(((CollectQuestTaskInfo)questInfo).ItemId);

        if (hasItem == true)
        {
            TaskComplete();
        }

        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged += CheckItemConditionTask;
    }

    private void TaskComplete()
    {
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged -= CheckItemConditionTask;
        questInfo.Effect.Execute(null);
    }

    private void CheckItemConditionTask(int id)
    {
        if (id == ((CollectQuestTaskInfo)questInfo).ItemId)
        {
            TaskComplete();
        }
    }
}

