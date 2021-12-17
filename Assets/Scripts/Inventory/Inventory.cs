using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ModificatorType]
public class Inventory
{
    [SerializeField]
    private List<int> itemsId;

    [Modificator]
    public List<int> ItemsId { get => itemsId; private set => itemsId = value; }

    public event System.Action<int> OnInventoryChanged = delegate { };

    public Inventory()
    {
        ItemsId = new List<int>();
    }

    public bool CheckHasItem(int id)
    {
        return ItemsId.Contains(id);
    }

    public void AddItem(int id)
    {
        ItemsId.Add(id);
        NotifyInventoryChanged(id);
    }

    public bool RemoveItem(int id)
    {
        for (int i = 0; i < ItemsId.Count; i++)
        {
            if (ItemsId[i] == id)
            {
                ItemsId.RemoveAt(i);
                NotifyInventoryChanged(id);
                return true;
            }
        }
        return false;
    }

    private void NotifyInventoryChanged(int id)
    {
        OnInventoryChanged(id);
    }
}