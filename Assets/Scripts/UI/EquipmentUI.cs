using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField]
    private SlotEquipment helmetSlot;
    [SerializeField]
    private SlotEquipment armorSlot;
    [SerializeField]
    private SlotEquipment legsSlot;
    [SerializeField]
    private SlotEquipment bootsSlot;
    [SerializeField]
    private SlotEquipment shieldSlot;
    [SerializeField]
    private SlotEquipment weaponSlot;

    public SlotEquipment HelmetSlot { get => helmetSlot; set => helmetSlot = value; }
    public SlotEquipment ArmorSlot { get => armorSlot; set => armorSlot = value; }
    public SlotEquipment LegsSlot { get => legsSlot; set => legsSlot = value; }
    public SlotEquipment BootsSlot { get => bootsSlot; set => bootsSlot = value; }
    public SlotEquipment ShieldSlot { get => shieldSlot; set => shieldSlot = value; }
    public SlotEquipment WeaponSlot { get => weaponSlot; set => weaponSlot = value; }

    private void Start()
    {
        Refresh(0);
        Player.Instance.Character.InventoryController.OnInventoryChanged += Refresh;
    }

    private void Refresh(int zmiennaDoUsuniecia)
    {
        Equipement equipement = Player.Instance.Character.InventoryController.Equipement;
        InitSlot(HelmetSlot, equipement.HelmetSlot);
        InitSlot(ArmorSlot, equipement.ArmorSlot);
        InitSlot(LegsSlot, equipement.LegsSlot);
        InitSlot(BootsSlot, equipement.BootsSlot);
        InitSlot(ShieldSlot, equipement.ShieldSlot);
        InitSlot(WeaponSlot, equipement.WeaponSlot);
    }

    private void InitSlot(SlotEquipment se, int id)
    {
        ItemInfo itemInfo = ItemsScriptableObject.Instance.GetItemInfoById(id);
        Item i = itemInfo?.CreateItem();
        se.Init(i);
    }
}