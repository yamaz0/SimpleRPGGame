using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShieldItemInfo: ItemInfo
{
    private const string LABEL_DEFENSE = "Defense: ";
    private const string LABEL_BLOCKCHANCE = "BlockChance: ";
    [SerializeField]
    private int defense;
    [SerializeField]
    private float blockChance;

    public int Defense { get => defense; set => defense = value; }
    public float BlockChance { get => blockChance; set => blockChance = value; }

    public ShieldItemInfo()
    {
        ItemType = ItemsManager.ItemType.EQUIPMENT;
    }

    public override Item CreateItem()
    {
        return new ShieldItem(this);
    }

    public override void CopyValues(ItemInfo item)
    {
        base.CopyValues(item);
        Defense = ((ShieldItemInfo)item).Defense;
        BlockChance = ((ShieldItemInfo)item).BlockChance;
    }

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        Defense = UnityEditor.EditorGUILayout.IntField(LABEL_DEFENSE, Defense);
        BlockChance = UnityEditor.EditorGUILayout.FloatField(LABEL_BLOCKCHANCE, BlockChance);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label(LABEL_DEFENSE + Defense.ToString());
        GUILayout.Label(LABEL_BLOCKCHANCE + BlockChance.ToString());
    }
#endif
}