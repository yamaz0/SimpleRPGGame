using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField]
    private List<SlotEquipment> equipmentSlots;

    public List<SlotEquipment> EquipmentSlots { get => equipmentSlots; set => equipmentSlots = value; }

    private void Start()
    {
        Refresh();
        Player.Instance.Character.InventoryController.OnInventoryChanged += Refresh;
    }

    private void OnValidate()
    {
        SlotEquipment[] slotEquipments = GetComponentsInChildren<SlotEquipment>();
        EquipmentSlots.AddRange(slotEquipments);
    }

    private void Refresh()
    {
        Equipement equipement = Player.Instance.Character.InventoryController.Equipement;

        foreach (var s in EquipmentSlots)
        {
            int id = equipement.GetItemIdByType(s.Eqtype);
            ItemInfo itemInfo = ItemsScriptableObject.Instance.GetItemInfoById(id);
            Item i = itemInfo?.CreateItem();
            s.Init(i);
        }
    }

}