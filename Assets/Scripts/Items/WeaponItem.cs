using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item, IEquipable, IUseable
{
    private int attack;
    private float attackSpeed;
    private bool isTwoHanded = false; // do wykorzystania potem

    public int Attack { get => attack; set => attack = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }

    public void Use()
    {
        Equip();
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

    public void Equip()
    {
        InventoryController inventoryController = Player.Instance.Character.InventoryController;
        int leftHandItemId = inventoryController.Equipement.GetItemIdByType(Equipement.EqType.HandLeft);

        if(leftHandItemId == Constants.NONE_EQUIP_ID)
        {
            inventoryController.EquipItem(this, Equipement.EqType.HandLeft);
        }
        else//TODO tutaj rozbudować o two handed bo nie mozna miec drugiego miecza jesli jest dwureczny
        {
            inventoryController.EquipItem(this, Equipement.EqType.HandRight);
        }
    }
}
