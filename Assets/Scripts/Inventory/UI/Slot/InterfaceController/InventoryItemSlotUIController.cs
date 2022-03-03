using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemSlotUIController : IItemSlotUIController
{
    public void DoubleClick(Slot slot)
    {
        if (slot.ItemCache is IUseable useable)
            useable.Use();
    }

    public void OnDrop(PointerEventData eventData, Slot slot)
    {
        List<RaycastResult> res = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, res);
        for (int i = 0; i < res.Count; i++)
        {
            SlotEquipment eqSlot = res[i].gameObject.GetComponent<SlotEquipment>();
            if (eqSlot != null)
            {
                if (slot.ItemCache is IEquipable tmp)
                {
                    bool isEquip = tmp.Equip(eqSlot.Eqtype);
                    if (isEquip == false)
                    {
                        Debug.Log("cant wear");
                    }
                    break;
                }
                else
                {
                    Debug.Log("its not equipable");
                }
            }
        }
        slot.transform.SetSiblingIndex(slot.Index);
        slot.transform.position = slot.StartPos;
        // gameObject.SetActive(false);
        // gameObject.SetActive(true);
    }
}
