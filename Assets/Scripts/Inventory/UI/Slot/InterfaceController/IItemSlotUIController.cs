using UnityEngine.EventSystems;

public interface IItemSlotUIController
{
    public void DoubleClick(Slot slot);
    public void OnDrop(PointerEventData eventData, Slot slot);
}
