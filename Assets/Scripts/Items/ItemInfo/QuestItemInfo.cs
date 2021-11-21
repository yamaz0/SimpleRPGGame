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

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        questId = UnityEditor.EditorGUILayout.IntField("QuestId: ", questId);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label("QuestId: " + QuestId.ToString());
    }
#endif
}