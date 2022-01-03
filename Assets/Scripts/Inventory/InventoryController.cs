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

    public Inventory Inventory { get => inventory; private set => inventory = value; }
    public Equipement Equipement { get => equipement; private set => equipement = value; }
    public event System.Action OnInventoryChanged = delegate { };

    public void AddItem(int itemId)
    {
        Inventory.AddItem(itemId);
        NotifyInventoryChanged();
    }

    public bool RemoveItem(int itemId)
    {
        bool isRemoved = Inventory.RemoveItem(itemId);
        if (isRemoved == true)
        {
            NotifyInventoryChanged();
        }
        return isRemoved;
    }

    public void EquipItem(Item i, Equipement.EqType type)
    {
        int oldEquipItemId = Equipement.EquipItem(i.Id, type);
        RemoveItem(i.Id);
        if (oldEquipItemId != Constants.NONE_EQUIP_ID)
        {
            AddItem(oldEquipItemId);
        }
    }
    private void NotifyInventoryChanged()
    {
        OnInventoryChanged();
    }
}
