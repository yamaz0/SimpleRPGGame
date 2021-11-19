using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestItemInfo: ItemInfo
{
    [SerializeField]
    private int questId;

    public int QuestId { get => questId; set => questId = value; }

    public QuestItemInfo()
    {
        ItemType = ItemsManager.ItemType.QUEST;
    }

    public ItemInfo Init(int id, string name, Sprite sprite, int questId)
    {
        InitBase(id, name, sprite);
        QuestId = questId;
        return this;
    }
}