using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipItemInfo : ItemInfo
{
    private const string LABEL = "Defense: ";
    [SerializeField]
    private int defense;
    [SerializeField]
    private Equipement.EqType equipmentType;

    public int Defense { get => defense; set => defense = value; }
    public Equipement.EqType EquipmentType { get => equipmentType; set => equipmentType = value; }

    public EquipItemInfo()
    {
        ItemType = ItemsManager.ItemType.EQUIPMENT;
    }

    public override Item CreateItem()
    {
        return new EquipItem(this);
    }

    public override void CopyValues(ItemInfo item)
    {
        base.CopyValues(item);
        Defense = ((EquipItemInfo)item).Defense;
    }

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        Defense = UnityEditor.EditorGUILayout.IntField(LABEL, defense);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label(LABEL + Defense.ToString());
        GUILayout.Label("EqElement: " + EquipmentType.ToString());
    }
#endif
}