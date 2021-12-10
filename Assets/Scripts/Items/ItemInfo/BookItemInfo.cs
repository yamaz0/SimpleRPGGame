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

    public override Item CreateItem()
    {
        return new BookItem(this);
    }

    public override void CopyValues(ItemInfo item)
    {
        base.CopyValues(item);
        BookXp = ((BookItemInfo)item).BookXp;
    }

#if UNITY_EDITOR
    public override void ShowFields()
    {
        base.ShowFields();
        BookXp = UnityEditor.EditorGUILayout.IntField("BookXp: ", bookXp);
    }

    public override void ShowAllItemInfo()
    {
        base.ShowAllItemInfo();
        GUILayout.Label("BookXp: " + BookXp.ToString());
    }
#endif
}