using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BookItemInfo: ItemsScriptableObject.ItemInfo
{
    [SerializeField]
    private int bookXp;

    public int BookXp { get => bookXp; set => bookXp = value; }
    public BookItemInfo()
    {
        ItemType = ItemsManager.ItemType.BOOK;
    }

    public ItemsScriptableObject.ItemInfo Init(int id, string name, int xp)
    {
        InitBase(id,name);
        BookXp = xp;
        return this;
    }

}