using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : Item
{
    int bookXp;

    public int BookXp { get => bookXp; set => bookXp = value; }
    public void Use()
    {
Debug.Log("BookItemUse");
    }

    public void Initialize(BookItemsScriptableObject.BookItemInfo info)
    {
        Id = info.Id;
        Name = info.Name;
        Type = info.ItemType;
        BookXp = info.BookXp;
    }

    public BookItem()
    {

    }
}
