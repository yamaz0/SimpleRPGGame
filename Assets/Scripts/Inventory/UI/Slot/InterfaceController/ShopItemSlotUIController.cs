using UnityEngine.EventSystems;

public class ShopItemSlotUIController : IItemSlotUIController
{
    public ShopInventory ShopInventoryController { get; private set; }

    public void Init(ShopInventory inv)
    {
        ShopInventoryController = inv;
    }

    public void DoubleClick(Slot slot)
    {
        ShopInventoryController.BuyItem(slot.ItemCache);
    }

    public void OnDrop(PointerEventData eventData, Slot slot)
    {
        throw new System.NotImplementedException();
    }
}
