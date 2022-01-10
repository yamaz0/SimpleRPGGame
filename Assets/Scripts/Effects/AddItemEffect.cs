using System;
using UnityEngine;

[System.Serializable]
public class AddItemEffect : OneCharacterEffect
{
    [SerializeField]
    [ItemDropdown]
    private int itemId;
    [SerializeField]
    private bool isRemove = false;
    public bool IsRemove { get => isRemove; set => isRemove = value; }
    public int ItemId { get => itemId; set => itemId = value; }

    public override void Execute(Character character)
    {
        if (IsRemove == true)
            character.InventoryController.RemoveItem(ItemId);
        else
            character.InventoryController.AddItem(ItemId);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
