using UnityEngine;

[System.Serializable]
public class Equipement
{
    [SerializeField]
    private int helmetSlot = -1;
    [SerializeField]
    private int armorSlot = -1;
    [SerializeField]
    private int legsSlot = -1;
    [SerializeField]
    private int bootsSlot = -1;
    [SerializeField]
    private int shieldSlot = -1;
    [SerializeField]
    private int weaponSlot = -1;

    public int HelmetSlot { get => helmetSlot; set => helmetSlot = value; }
    public int ArmorSlot { get => armorSlot; set => armorSlot = value; }
    public int LegsSlot { get => legsSlot; set => legsSlot = value; }
    public int BootsSlot { get => bootsSlot; set => bootsSlot = value; }
    public int ShieldSlot { get => shieldSlot; set => shieldSlot = value; }
    public int WeaponSlot { get => weaponSlot; set => weaponSlot = value; }

    public int EquipItem(int id, EqType type)
    {
        int oldItemId = Constants.NONE_EQUIP_ID;
        switch (type)
        {
            case EqType.HELMET:
                oldItemId = HelmetSlot;
                HelmetSlot = id;
                break;
            case EqType.ARMOR:
                oldItemId = ArmorSlot;
                ArmorSlot = id;
                break;
            case EqType.LEGS:
                oldItemId = LegsSlot;
                LegsSlot = id;
                break;
            case EqType.BOOTS:
                oldItemId = BootsSlot;
                BootsSlot = id;
                break;
            case EqType.SHIELD:
                oldItemId = ShieldSlot;
                ShieldSlot = id;
                break;
            case EqType.WEAPON:
                oldItemId = WeaponSlot;
                WeaponSlot = id;
                break;
            default:
                Debug.LogError("Equipment type error. Cant equip item");
                break;
        }

        return oldItemId;
    }

    public enum EqType { HELMET, ARMOR, LEGS, BOOTS, SHIELD, WEAPON };
}