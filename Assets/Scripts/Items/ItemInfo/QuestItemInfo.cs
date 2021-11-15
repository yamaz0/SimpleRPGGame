using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestItemInfo: ItemsScriptableObject.ItemInfo
{
    [SerializeField]
    private int questId;

    public int QuestId { get => questId; set => questId = value; }
    public QuestItemInfo()
    {
        ItemType=ItemsManager.ItemType.QUEST;
    }
    public ItemsScriptableObject.ItemInfo Init(int id, string name, int questId)
    {
        InitBase(id,name);
        QuestId = questId;
        return this;
    }
}