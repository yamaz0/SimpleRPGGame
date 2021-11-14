using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;
    // [SerializeField]
    // private ItemsManager.ItemType type;

    // public string Name { get => name; set => name = value; }
    // public int Id { get => id; set => id = value; }
    // public ItemsManager.ItemType Type { get => type; set => type = value; }
    // protected Item(int id, string name, ItemsManager.ItemType itemType)
    // {
    //     Id = id;
    //     Name = name;
    //     Type = itemType;
    // }
}
