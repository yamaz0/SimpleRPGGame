using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEquipable
{
    public void Equip(Equipement.EqType type);
}
public interface IUseable
{
    public void Use();
}
public class EquipItem : Item, IEquipable, IUseable
{
    [SerializeField]
    private int defense;
    [SerializeField]
    private Equipement.EqType equipmentType;

    public int Defense { get => defense; set => defense = value; }
    public Equipement.EqType EquipmentType { get => equipmentType; set => equipmentType = value; }

    public void Use()
    {
        Equip(EquipmentType);
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

    public void Equip(Equipement.EqType type)
    {
        if (type == EquipmentType)
            Player.Instance.Character.InventoryController.EquipItem(this, type);
    }
}
