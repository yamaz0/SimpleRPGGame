using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestItemInfo : ItemInfo
{
    private const string LABEL = "QuestId: ";
    [SerializeField]
    private int questId;

    public int QuestId { get => questId; set => questId = value; }

    public QuestItemInfo()
    {
        ItemType = ItemsManager.ItemType.QUEST;
    }

    public override Item CreateItem()
    {
        return new QuestItem(this);
    }

    public override void CopyValues(ItemInfo item)
    {
        base.CopyValues(item);
        QuestId = ((QuestItemInfo)item).QuestId;
    }

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        QuestId = UnityEditor.EditorGUILayout.IntField(LABEL, questId);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label(LABEL + QuestId.ToString());
    }
#endif
}