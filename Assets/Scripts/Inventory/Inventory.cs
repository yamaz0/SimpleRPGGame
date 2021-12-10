using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable][ModificatorType]
public class Inventory
{
    [SerializeField]
    private List<int> itemsIds;
    [Modificator]
    public List<int> ItemsIds { get => itemsIds; set => itemsIds = value; }

    public Inventory()
    {
        ItemsIds = new List<int>();
    }

    public void AddItem(int id)
    {
        ItemsIds.Add(id);
    }

    public void RemoveItem(int id)
    {
        ItemsIds.Remove(id);
    }
}
