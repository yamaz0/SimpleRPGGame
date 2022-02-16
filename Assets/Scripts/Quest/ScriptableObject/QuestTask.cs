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

    public string Title { get => title; set => title = value; }
    public string Desc { get => desc; set => desc = value; }
    public int OrderNumber { get => orderNumber; set => orderNumber = value; }
}

[System.Serializable]
public class InteractQuestTask: QuestTask
{
    [SerializeField]
    private StartQuestEffect effect = new StartQuestEffect();

    public void Init()
    {
        // interactGameObject.Efects.Add(effect);
    }
}