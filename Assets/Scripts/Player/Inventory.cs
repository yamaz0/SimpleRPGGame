using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField]
    private List<(ItemsManager.ItemType itemType, int id)> itemsIds;

    public List<(ItemsManager.ItemType itemType, int id)> ItemsIds { get => itemsIds; set => itemsIds = value; }

    public Inventory()
    {
        ItemsIds = new List<(ItemsManager.ItemType itemType, int id)>();
    }
    public void AddItem(ItemsManager.ItemType itemType, int id)
    {
        ItemsIds.Add((itemType, id));
    }


}
