using System;
using UnityEngine;

[System.Serializable]
public class AddItemEffect : OneCharacterEffect
{
    [SerializeField]
    [IdDropdown(typeof(ItemsScriptableObject))]
    private int itemId;
    [SerializeField]
    private bool isRemove = false;
    public bool IsRemove { get => isRemove; set => isRemove = value; }
    public int ItemId { get => itemId; set => itemId = value; }

    public override void Execute(Character character)
    {
        Item item = ItemsScriptableObject.Instance.GetItemInfoById(ItemId).CreateItem();

        if (IsRemove == true)
        {
            bool isRemoved = character.InventoryController.RemoveItem(item);
            if (character == Player.Instance.Character && isRemoved == true)
                PopUpManager.Instance.ShowNotification($"Remove item: {item.Name}", item.Icon);
        }
        else
        {
            character.InventoryController.AddItem(item);
            if (character == Player.Instance.Character)
                PopUpManager.Instance.ShowNotification($"New item: {item.Name}", item.Icon);
        }
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        return $"Added item: {ItemsScriptableObject.Instance.GetItemInfoById(ItemId).Name}.";
    }
}
