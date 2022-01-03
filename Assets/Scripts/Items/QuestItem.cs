using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : Item, IUseable
{
    int questId;

    public int QuestId { get => questId; set => questId = value; }

    public void Use()
    {
        Debug.Log("QuestItemUse");
    }

    public QuestItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        QuestId = ((QuestItemInfo)info).QuestId;
    }
}
