using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : Item, IUseable
{
    int bookXp;

    public int BookXp { get => bookXp; set => bookXp = value; }
    public void Use()
    {
        Debug.Log("BookItemUse");
    }

    public BookItem(ItemInfo info)
    {
        Init(info);
    }

    protected override void Init(ItemInfo info)
    {
        base.Init(info);
        BookXp = ((BookItemInfo)info).BookXp;
    }
}
