using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public override string GetDescription()
    {
        StringBuilder desc = new StringBuilder();
        desc.Append($"Defense: {Defense} {System.Environment.NewLine}");
        desc.Append($"BlockChance: {BlockChance} {System.Environment.NewLine}");
        return desc.ToString();
    }

    public bool Equip(Equipement.EqType type)
    {
        if (type == Equipement.EqType.HandRight)
        {
            Character character = Player.Instance.Character;
            InventoryController inventoryController = character.InventoryController;

            Item item = inventoryController.GetItemByType(type);

            if (item != null || character.Style != FightStyle.TwoHand)
            {
                inventoryController.EquipItem(this, type);
                character.Style = FightStyle.OneHand;
                return true;
            }
        }
        return false;
    }
}
