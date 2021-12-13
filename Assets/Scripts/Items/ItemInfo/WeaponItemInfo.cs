using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponItemInfo: ItemInfo
{
    private const string LABEL = "Attack: ";

    [SerializeField]
    private int attack;

    public int Attack { get => attack; set => attack = value; }

    public WeaponItemInfo()
    {
        ItemType = ItemsManager.ItemType.OTHER;
    }

    public override Item CreateItem()
    {
        return new WeaponItem(this);
    }

    public override void CopyValues(ItemInfo item)
    {
        base.CopyValues(item);
        Attack = ((WeaponItemInfo)item).Attack;
    }

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        Attack = UnityEditor.EditorGUILayout.IntField(LABEL, attack);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label(LABEL + Attack.ToString());
    }
#endif
}