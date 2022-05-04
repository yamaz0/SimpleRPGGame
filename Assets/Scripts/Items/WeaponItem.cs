using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public override string GetDescription()
    {
        StringBuilder desc = new StringBuilder();
        desc.Append($"Attack: {Attack}{System.Environment.NewLine}");
        desc.Append($"AtkSpeed: {AttackSpeed}{System.Environment.NewLine}");
        if (TwoHanded == true)
        {
            desc.Append($"TwoHanded{System.Environment.NewLine}");
        }
        else
        {
            desc.Append($"One Hand{System.Environment.NewLine}");
        }

        return desc.ToString();
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
            Character character = Player.Instance.Character;
            InventoryController inventoryController = character.InventoryController;

            if (TwoHanded == true || character.Style == FightStyle.TwoHand)
            {
                TryUnequipItem(inventoryController, Equipement.EqType.HandLeft);
                TryUnequipItem(inventoryController, Equipement.EqType.HandRight);
            }
            else
            {
                if (type == Equipement.EqType.HandRight)
                {
                    Item item = inventoryController.GetItemByType(Equipement.EqType.HandLeft);

                    if (item == null)
                    {
                        type = Equipement.EqType.HandLeft;
                    }
                }
            }
            inventoryController.EquipItem(this, type);

            UpdateCharacterStyle(character, inventoryController);
            return true;
        }
        return false;
    }

    private void UpdateCharacterStyle(Character character, InventoryController inventoryController)
    {
        Item itemL = inventoryController.GetItemByType(Equipement.EqType.HandLeft);
        Item itemR = inventoryController.GetItemByType(Equipement.EqType.HandRight);

        if (itemL != null && itemR != null && itemL is WeaponItem && itemR is WeaponItem)
        {
            character.Style = FightStyle.DualWield;
        }
        else if (itemR != null && itemR is WeaponItem weaponR)
        {
            character.Style = weaponR.TwoHanded == true ? FightStyle.TwoHand : FightStyle.OneHand;
        }
        else if (itemL != null && itemL is WeaponItem weaponL)
        {
            character.Style = weaponL.TwoHanded == true ? FightStyle.TwoHand : FightStyle.OneHand;
        }
    }
}
