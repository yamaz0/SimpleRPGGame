using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StartQuestEffect : OneCharacterEffect
{
    [SerializeField]
    [IdDropdown(typeof(QuestScriptableObject))]
    private int questId;

    public int QuestId { get => questId; set => questId = value; }

    public override void Execute(Character character)
    {
        BaseInfo baseInfo = QuestScriptableObject.Instance.Objects.GetElementById(QuestId);
        if (baseInfo is MainQuestInfo mainQuest)
        {
            Player.Instance.PlayerQuestController.UpdateMainQuestId(QuestId);
        }
        else if (baseInfo is SideQuestInfo sideQuest)
        {
            Player.Instance.PlayerQuestController.AddActualSideQuestsId(QuestId);
        }
    }

    public override void Remove(Character character)
    {
        Player.Instance.PlayerQuestController.RemoveSideQuestsId(QuestId);
    }
}
