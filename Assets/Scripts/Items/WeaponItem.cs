using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item, IEquipable, IUseable
{
    private int attack;
    private float attackSpeed;
    private bool twoHanded;

    public int Attack { get => attack; set => attack = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public bool TwoHanded { get => twoHanded; set => twoHanded = value; }

    public void Use()
    {
        InventoryController inventoryController = Player.Instance.Character.InventoryController;
        Item leftHandItem = inventoryController.GetItemByType(Equipement.EqType.HandLeft);
        Item rightHandItem = inventoryController.GetItemByType(Equipement.EqType.HandRight);
        Equipement.EqType EquipSlotType = leftHandItem != null && rightHandItem == null ? Equipement.EqType.HandRight : Equipement.EqType.HandLeft;

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
        TwoHanded = ((WeaponItemInfo)info).TwoHanded;
    }

    private void TryUnequipItem(InventoryController inventoryController, Equipement.EqType type)
    {
        Item item = inventoryController.GetItemByType(type);
        if (item != null) inventoryController.EquipItem(null, type);
    }

    public bool Equip(Equipement.EqType type)
    {
        if (type == Equipement.EqType.HandLeft || type == Equipement.EqType.HandRight)
        {
            InventoryController inventoryController = Player.Instance.Character.InventoryController;

            if (TwoHanded == true)
            {
                TryUnequipItem(inventoryController,Equipement.EqType.HandLeft);
                TryUnequipItem(inventoryController,Equipement.EqType.HandRight);

                inventoryController.IsTwoHandedEquip = true;
            }
            else if (inventoryController.IsTwoHandedEquip == true)
            {
                if (TryUnequipTwoHandedWeapon(inventoryController, Equipement.EqType.HandLeft)
                 || TryUnequipTwoHandedWeapon(inventoryController, Equipement.EqType.HandRight))
                {
                    inventoryController.IsTwoHandedEquip = false;
                }
            }

            inventoryController.EquipItem(this, type);
            return true;
        }
        return false;
    }


    private bool TryUnequipTwoHandedWeapon(InventoryController inventoryController, Equipement.EqType type)
    {
        Item item = inventoryController.GetItemByType(type);
        if (CheckItemIsTwoHanded(item) == true)
        {
            inventoryController.EquipItem(null, type);
            return true;
        }
        return false;
    }

    private bool CheckItemIsTwoHanded(Item item)
    {
        if (item is WeaponItem weaponItem)
            return weaponItem.TwoHanded;
        return false;
    }
}
