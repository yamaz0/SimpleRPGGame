using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : Item
{
    private int defense;

    public int Defense { get => defense; set => defense = value; }

    public override void Use()
    {
        Debug.Log("ArmorItemUse");
    }

    public EquipItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        Defense = ((EquipItemInfo)info).Defense;
    }
}
