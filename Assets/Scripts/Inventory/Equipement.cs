using UnityEngine;

[System.Serializable]
public class Equipement
{
    [SerializeField]
    private int[] equipmentSlots = new int[Constants.EQUIPMENT_SLOTS_NUMBER];

    ///<summary>
    ///Set new item id and return old item id.
    ///</summary>
    public int EquipItem(int id, EqType type)
    {
        int oldItemId = equipmentSlots[(int)type];
        equipmentSlots[(int)type] = id;

        return oldItemId;
    }

    public int GetItemIdByType(EqType type)
    {
        return equipmentSlots[(int)type];
    }

    public enum EqType { Helmet, Armor, Legs, Boots, HandLeft, HandRight };
}