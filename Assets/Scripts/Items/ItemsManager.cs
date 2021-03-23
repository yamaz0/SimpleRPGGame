using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : Singleton<ItemsManager>
{
    public T GetItem<T>(ItemType type, int id) where T: Item,new()
    {
        switch (type)
        {
            case ItemType.OTHER:
                break;
            case ItemType.USE:
                break;
            case ItemType.INGREDIENT:
                break;
            case ItemType.BOOK:
                BookItem bookItem = new BookItem();
                bookItem.Initialize(BookItemsScriptableObject.Instance.GetItemInfoById(id));
                return (T)(Item)bookItem;
            case ItemType.QUEST:
                QuestItem questItem = new QuestItem();
                questItem.Initialize(QuestItemsScriptableObject.Instance.GetItemInfoById(id));
                return (T)(Item)questItem;
            default:
            Debug.LogError("ItemType incorrect!");
                return null;
        }

        return null;
    }

    public enum ItemType
    {
        OTHER,
        USE,
        INGREDIENT,
        BOOK,
        QUEST
    }
}
