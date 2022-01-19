using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryController
{
    [SerializeField]
    private Inventory inventory = new Inventory();
    [SerializeField]
    private Equipement equipement = new Equipement();
    [SerializeField]
    private bool isTwoHandedEquip;

    public Inventory Inventory { get => inventory; set => inventory = value; }
    public Equipement Equipement { get => equipement; set => equipement = value; }
    public bool IsTwoHandedEquip { get => isTwoHandedEquip; set => isTwoHandedEquip = value; }

    public void Init()
    {
        Equipement.Init();
        Inventory.Init();
    }

    public void AddItem(int itemId)
    {
        Item item = ItemsScriptableObject.Instance.GetItemInfoById(itemId).CreateItem();
        AddItem(item);
    }

    public void AddItem(Item item)
    {
        Inventory.AddItem(item);
    }

    public bool RemoveItem(Item item)
    {
        return Inventory.RemoveItem(x => x.Equals(item));
    }

    public bool RemoveItem(int itemId)
    {
        return Inventory.RemoveItem(x => x.Id.Equals(itemId));
    }

    public Item GetItemByType(Equipement.EqType type)
    {
        return Equipement.GetItemByType(type);
    }

    public void EquipItem(Item item, Equipement.EqType type)
    {
        Item oldEquipItem = Equipement.EquipItem(item, type);

        if (oldEquipItem != null)
        {
            AddItem(oldEquipItem);
        }
        if (item != null)
        {
            RemoveItem(item);
        }
    }
}
