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
        // Refresh();
        // Player.Instance.Character.InventoryController.Equipement.OnEquipmentChanged += Refresh;
    }
    private void OnEnable()
    {
        Refresh();
        Player.Instance.Character.InventoryController.Equipement.OnEquipmentChanged += Refresh;
    }
    private void OnDisable()
    {
        Player.Instance.Character.InventoryController.Equipement.OnEquipmentChanged -= Refresh;
    }

    // private void OnValidate()
    // {
    //     SlotEquipment[] slotEquipments = GetComponentsInChildren<SlotEquipment>();
    //     EquipmentSlots.AddRange(slotEquipments);
    // }

    private void Refresh()
    {
        InventoryController equipement = Player.Instance.Character.InventoryController;
        EquipmentItemSlotUIController ctrl = new EquipmentItemSlotUIController();

        foreach (var s in EquipmentSlots)
        {
            s.Init(equipement.GetItemByType(s.Eqtype), ctrl);
        }
    }

}