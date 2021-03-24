using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField]
    private List<(ItemsManager.ItemType itemType, int id)> itemsIds;

    public List<(ItemsManager.ItemType itemType, int id)> ItemsIds { get => itemsIds; set => itemsIds = value; }

    public List<Item> itemList;
}
