using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : Item<QuestItemsScriptableObject, QuestItemsScriptableObject.QuestItemInfo>
{
    int questId;

    public int QuestId { get => questId; set => questId = value; }

    public QuestItem(QuestItemsScriptableObject.QuestItemInfo info):base(info)
    {
        QuestId = info.QuestId;
    }
}
