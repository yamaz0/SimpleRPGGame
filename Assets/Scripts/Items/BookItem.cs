using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : Item<BookItemsScriptableObject, BookItemsScriptableObject.BookItemInfo>
{
    int bookXp;

    public int BookXp { get => bookXp; set => bookXp = value; }
    public void Use()
    {
Debug.Log("BookItemUse");
    }

    public BookItem(BookItemsScriptableObject.BookItemInfo info):base(info)
    {
        BookXp = info.BookXp;
    }
}
