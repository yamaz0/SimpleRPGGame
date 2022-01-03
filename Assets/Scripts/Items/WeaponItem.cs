using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item, IEquipable, IUseable
{
    private int attack;
    private float attackSpeed;

    public int Attack { get => attack; set => attack = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }

    public void Use()
    {
        InventoryController inventoryController = Player.Instance.Character.InventoryController;
        int leftHandItemId = inventoryController.Equipement.GetItemIdByType(Equipement.EqType.HandLeft);
        Equipement.EqType EquipSlotType = leftHandItemId == Constants.NONE_EQUIP_ID ? Equipement.EqType.HandLeft : Equipement.EqType.HandRight;

        Equip(EquipSlotType);
    }

    public WeaponItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        Attack = ((WeaponItemInfo)info).Attack;
        AttackSpeed = ((WeaponItemInfo)info).AttackSpeed;
    }

    public void Equip(Equipement.EqType type)
    {
        if (type == Equipement.EqType.HandLeft || type == Equipement.EqType.HandRight)
        {
            InventoryController inventoryController = Player.Instance.Character.InventoryController;
            inventoryController.EquipItem(this, type);
        }
    }
}
