using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BookItemInfo: ItemInfo
{
    [SerializeField]
    private int bookXp;

    public int BookXp { get => bookXp; set => bookXp = value; }

    public BookItemInfo()
    {
        ItemType = ItemsManager.ItemType.BOOK;
    }

    public ItemInfo Init(int id, string name, Sprite sprite, int xp)
    {
        InitBase(id, name, sprite);
        BookXp = xp;
        return this;
    }

}