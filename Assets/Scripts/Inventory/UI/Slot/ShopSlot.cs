using UnityEngine;

[System.Serializable]
public class ShopSlot : Slot
{
    [SerializeField]
    private ItemShopUI itemShopUI;

    public override void Init(Item item, IItemSlotUIController slotController)
    {
        base.Init(item, slotController);
        itemShopUI.Init(item);
    }

}
