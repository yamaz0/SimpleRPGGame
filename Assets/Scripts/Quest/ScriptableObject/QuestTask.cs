using UnityEngine;

[System.Serializable]
public class QuestTask
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
}

[System.Serializable]
public class InteractQuestTask : QuestTask
{

    public void Init(InteractObject interactGameObject)
    {
        interactGameObject.Efects.Add(Effect);
    }
}

[System.Serializable]
public class CollectQuestTask : QuestTask
{
    [SerializeField]
    [IdDropdown(typeof(ItemsScriptableObject))]
    private int itemId;

    public void Init()
    {
        bool hasItem = Player.Instance.Character.InventoryController.Inventory.ItemsId.Contains(itemId);

        if (hasItem == true)
        {
            TaskCompleteExecute();
        }

        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged += CheckItemConditionTask;
    }

    private void TaskCompleteExecute()
    {
        Effect.Execute(null);
    }

    private void CheckItemConditionTask(int id)
    {
        if (id == itemId)
        {
            TaskCompleteExecute();
        }
    }
}