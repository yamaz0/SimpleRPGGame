using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : Item, IEquipable, IUseable
{
    private int defense;
    private float blockChance;

    public int Defense { get => defense; set => defense = value; }
    public float BlockChance { get => blockChance; set => blockChance = value; }

    public void Use()
    {
        Equip(Equipement.EqType.HandRight);
    }

    public ShieldItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        Defense = ((ShieldItemInfo)info).Defense;
        BlockChance = ((ShieldItemInfo)info).BlockChance;
    }

    public bool Equip(Equipement.EqType type)
    {
        if (type == Equipement.EqType.HandRight)
        {
            InventoryController inventoryController = Player.Instance.Character.InventoryController;

            Item item = inventoryController.GetItemByType(type);

            if (item != null || inventoryController.IsTwoHandedEquip == false)
            {
                inventoryController.EquipItem(this, type);
                inventoryController.IsTwoHandedEquip = false;
                return true;
            }
        }
        return false;
    }
}
