using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ModificatorType]
public class Inventory
{
    [SerializeField]
    private List<int> itemsId = new List<int>();
    [SerializeField]
    private int gold;

    [Modificator]
    public List<int> ItemsId { get => itemsId; private set => itemsId = value; }

    public List<Item> Items { get; set; }
    public int Gold { get => gold; set => gold = value; }

    public event System.Action<int> OnInventoryChanged = delegate { };
    public event System.Action<int> OnGoldValueChanged = delegate { };

    public bool AddGold(int value)
    {
        int newGoldValue = Gold + value;

        if (newGoldValue < 0)
        {
            return false;
        }

        Gold = newGoldValue;
        OnGoldValueChanged(Gold);

        return true;
    }

    public void Init()
    {
        if (ItemsId == null)
            ItemsId = new List<int>();

        Items = new List<Item>();

        for (int i = 0; i < ItemsId.Count; i++)
        {
            Item item = ItemsScriptableObject.Instance.GetItemInfoById(ItemsId[i])?.CreateItem();//usunac kiedys ten pytajnik
            Items.Add(item);
        }
    }

    public void AddItem(Item item)
    {
        ItemsId.Add(item.Id);
        Items.Add(item);

        NotifyInventoryChanged(item.Id);
    }

    public bool RemoveItem(System.Predicate<Item> match)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (match(Items[i]) == true)
            {
                RemoveItemsAtIndex(i);
                return true;
            }
        }
        return false;
    }

    private void RemoveItemsAtIndex(int i)
    {
        int id = ItemsId[i];

        ItemsId.RemoveAt(i);
        Items.RemoveAt(i);

        NotifyInventoryChanged(id);
    }

    private void NotifyInventoryChanged(int id)
    {
        OnInventoryChanged(id);
    }
}