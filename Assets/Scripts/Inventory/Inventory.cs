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


    public Inventory()
    {
        if (ItemsId == null)
            ItemsId = new List<int>();
    }

    public bool CheckHasItem(int id)
    {
        return ItemsId.Contains(id);
    }

    public void AddItem(int id)
    {
        ItemsId.Add(id);
    }

    public bool RemoveItem(int id)
    {
        for (int i = 0; i < ItemsId.Count; i++)
        {
            if (ItemsId[i] == id)
            {
                ItemsId.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

}