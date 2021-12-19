using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEquipable
{
    public void Equip();
}
public class EquipItem : Item, IEquipable
{
    [SerializeField]
    private int defense;
    [SerializeField]
    private Equipement.EqType equipmentType;

    public int Defense { get => defense; set => defense = value; }
    public Equipement.EqType EquipmentType { get => equipmentType; set => equipmentType = value; }

    public override void Use()
    {
        Equip();
    }

    public EquipItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        Defense = ((EquipItemInfo)info).Defense;
        EquipmentType = ((EquipItemInfo)info).EquipmentType;
    }

    public void Equip()
    {
        Player.Instance.Character.InventoryController.EquipItem(this, EquipmentType);
    }
}
