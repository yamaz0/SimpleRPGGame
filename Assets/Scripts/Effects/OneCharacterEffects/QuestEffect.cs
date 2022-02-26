using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestEffect : OneCharacterEffect
{
    [SerializeField]
    [IdDropdown(typeof(QuestScriptableObject))]
    private int questId;

    public int QuestId { get => questId; set => questId = value; }

    public override void Execute(Character character)
    {
        QuestManager.Instance.QuestUpdate(QuestId);
    }

    public override void Remove(Character character)
    {
        QuestManager.Instance.QuestRemove(QuestId);
    }
}

[System.Serializable]
public class RemoveQuestEffect : OneCharacterEffect
{
    [SerializeField]
    [IdDropdown(typeof(QuestScriptableObject))]
    private int questId;

    public int QuestId { get => questId; set => questId = value; }

    public override void Execute(Character character)
    {
        Player.Instance.PlayerQuestController.RemoveActualQuestById(QuestId);
    }

    public override void Remove(Character character)
    {
    }
}
