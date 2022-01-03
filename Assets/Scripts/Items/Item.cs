using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdable
{
    int Id{ get;}
}

public interface INameable
{
    string Name{ get;}
}

public abstract class Item : IIdable, INameable
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;
    [SerializeField]
    private ItemsManager.ItemType type;
    [SerializeField]
    private Sprite icon;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public ItemsManager.ItemType Type { get => type; set => type = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    protected virtual void Init(ItemInfo info)
    {
        Id = info.Id;
        Name = info.Name;
        Type = info.ItemType;
        Icon = info.Icon;
    }

    // public abstract string GetFullText(); // do tooltipa czy cos
}
