using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : Item
{
    int questId;

    public int QuestId { get => questId; set => questId = value; }

    public void Initialize(QuestItemsScriptableObject.QuestItemInfo info)
    {
        Id = info.Id;
        Name = info.Name;
        Type = info.ItemType;
        QuestId = info.QuestId;
    }

    public QuestItem()
    {

    }
}
