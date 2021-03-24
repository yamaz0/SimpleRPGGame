using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : Item
{
    int questId;

    public int QuestId { get => questId; set => questId = value; }

    public QuestItem(QuestItemsScriptableObject.QuestItemInfo info):base(info.Id, info.Name, info.ItemType)
    {
        QuestId = info.QuestId;
    }
}
