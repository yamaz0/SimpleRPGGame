using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipement
{
    [SerializeField]
    private int[] itemsId;

    public List<Item> Items { get; set; }

    public event System.Action OnEquipmentChanged = delegate { };

    public Equipement()
    {
        InitializeEquipmentSlots();
    }

    public void Init()
    {
        if (itemsId == null || itemsId.Length != Constants.EQUIPMENT_SLOTS_NUMBER)
        {
            InitializeEquipmentSlots();
        }

        Items = new List<Item>(Constants.EQUIPMENT_SLOTS_NUMBER);

        foreach (var itemId in itemsId)
        {
            Item item = ItemsScriptableObject.Instance.GetItemInfoById(itemId)?.CreateItem();
            Items.Add(item);
        }
    }

    public void InitializeEquipmentSlots()
    {
        itemsId = new int[Constants.EQUIPMENT_SLOTS_NUMBER];
        for (int i = 0; i < Constants.EQUIPMENT_SLOTS_NUMBER; i++)
        {
            itemsId[i] = Constants.NONE_EQUIP_ID;
        }
    }

    ///<summary>
    ///Set new item and return old item.
    ///</summary>
    public Item EquipItem(Item item, EqType type)
    {
        int id = item != null ? item.Id : Constants.NONE_EQUIP_ID;
        Item oldItem = Items[(int)type];

        itemsId[(int)type] = id;
        Items[(int)type] = item;

        NotifyEquipmentChanged();

        return oldItem;
    }

    private void NotifyEquipmentChanged()
    {
        OnEquipmentChanged();
    }

    public Item GetItemByType(EqType type)
    {
        return Items[(int)type];
    }

    public enum EqType { Helmet, Armor, Legs, Boots, HandLeft, HandRight };
}