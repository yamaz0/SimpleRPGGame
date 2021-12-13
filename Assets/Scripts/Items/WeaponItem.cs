using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    private int attack;

    public int Attack { get => attack; set => attack = value; }

    public override void Use()
    {
        Debug.Log("example");
    }

    public WeaponItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        Attack = ((WeaponItemInfo)info).Attack;
    }
}
