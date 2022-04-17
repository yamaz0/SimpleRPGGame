using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;
    [SerializeField]
    private ItemsManager.ItemType type;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int price;
    [SerializeField]
    private int unlockLevel;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public ItemsManager.ItemType Type { get => type; set => type = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public int Price { get => price; set => price = value; }
    public int UnlockLevel { get => unlockLevel; set => unlockLevel = value; }

    protected virtual void Init(ItemInfo info)
    {
        Id = info.Id;
        Name = info.Name;
        Type = info.ItemType;
        Icon = info.Icon;
        Price = info.Price;
        UnlockLevel = info.UnlockLevel;
    }

    public virtual string GetDescription()
    {
        return System.Environment.NewLine;
    }

    // public abstract string GetFullText(); // do tooltipa czy cos
}
