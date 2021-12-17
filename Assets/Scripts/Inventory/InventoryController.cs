using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryController
{
    [SerializeField]
    private Inventory inventory = new Inventory();
    [SerializeField]
    private Equipement equipement;

    public Inventory Inventory { get => inventory; private set => inventory = value; }
    public Equipement Equipement { get => equipement; private set => equipement = value; }

    public void AddItem(int itemId)
    {
        Inventory.AddItem(itemId);
    }

    public bool RemoveItem(int itemId)
    {
        return Inventory.RemoveItem(itemId);
    }

    public void EquipItem(Slot itemSlot)
    {

    }
}
