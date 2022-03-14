using System.Collections.Generic;
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
        List<RaycastResult> res = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, res);
        for (int i = 0; i < res.Count; i++)
        {
            ShopInventory inventory = res[i].gameObject.GetComponent<ShopInventory>();
            if (inventory != null && inventory != ShopInventoryController)
            {
                ShopInventoryController.BuyItem(slot.ItemCache);
                break;
            }
        }
        slot.transform.SetSiblingIndex(slot.Index);
        slot.transform.position = slot.StartPos;
        slot.gameObject.SetActive(false);
        slot.gameObject.SetActive(true);
    }
}
