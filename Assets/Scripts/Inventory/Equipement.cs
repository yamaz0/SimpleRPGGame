using UnityEngine;

public class Equipement
{
    private const int NONE_EQUIP = -1;
    [SerializeField]
    private Slot helmetSlot = new Slot(NONE_EQUIP);
    [SerializeField]
    private Slot armorSlot = new Slot(NONE_EQUIP);
    [SerializeField]
    private Slot legsSlot = new Slot(NONE_EQUIP);
    [SerializeField]
    private Slot bootsSlot = new Slot(NONE_EQUIP);
    [SerializeField]
    private Slot shieldSlot = new Slot(NONE_EQUIP);
    [SerializeField]
    private Slot weaponSlot = new Slot(NONE_EQUIP);

    public Slot HelmetSlot { get => helmetSlot; set => helmetSlot = value; }
    public Slot ArmorSlot { get => armorSlot; set => armorSlot = value; }
    public Slot LegsSlot { get => legsSlot; set => legsSlot = value; }
    public Slot BootsSlot { get => bootsSlot; set => bootsSlot = value; }
    public Slot ShieldSlot { get => shieldSlot; set => shieldSlot = value; }
    public Slot WeaponSlot { get => weaponSlot; set => weaponSlot = value; }

    public void WearItem(EquipItemInfo item, EqType type)
    {
        // if(item.)
        Slot targetEquipmentSlot = GetEquipemntByType(type);

        if (targetEquipmentSlot != null)
        {
            if (targetEquipmentSlot.Id != NONE_EQUIP)
            {
                Player.Instance.Character.Inventory.AddItem(targetEquipmentSlot.Id);
            }

            targetEquipmentSlot.Id = item.Id;
        }
    }

    public Slot GetEquipemntByType(EqType type)
    {
        switch (type)
        {
            case EqType.HELMET:
                return HelmetSlot;
            case EqType.ARMOR:
                return ArmorSlot;
            case EqType.LEGS:
                return LegsSlot;
            case EqType.BOOTS:
                return BootsSlot;
            case EqType.SHIELD:
                return ShieldSlot;
            case EqType.WEAPON:
                return WeaponSlot;
            default:
                return null;
        }
    }

    public enum EqType { HELMET, ARMOR, LEGS, BOOTS, SHIELD, WEAPON };
}

public class Slot
{
    private int id;

    public int Id { get => id; set => id = value; }
    public Slot(int itemId)
    {
        Id = itemId;
    }
}