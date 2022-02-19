using UnityEngine;

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
