using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item<T,Y>
    where Y : ItemsScriptableObject<T,Y>.ItemInfo
    where T:ItemsScriptableObject<T,Y>
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;
    [SerializeField]
    private ItemsManager.ItemType type;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public ItemsManager.ItemType Type { get => type; set => type = value; }
    protected Item(ItemsScriptableObject<T,Y>.ItemInfo info)
    {
        Id = info.Id;
        Name = info.Name;
        Type = info.ItemType;
    }
}
