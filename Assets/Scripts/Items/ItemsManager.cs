using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : Singleton<ItemsManager>
{

    // public BookItem CreateBookItem(int id)
    // {
    //     return new BookItem(BookItemsScriptableObject.Instance.GetItemInfoById(id));
    // }

    // public BookItem CreateBookItem(string name)
    // {
    //     return new BookItem(BookItemsScriptableObject.Instance.GetItemInfoByName(name));
    // }

    // public QuestItem CreateQuestItem(int id)
    // {
    //     return new QuestItem(QuestItemsScriptableObject.Instance.GetItemInfoById(id));
    // }

    // public QuestItem CreateQuestItem(string name)
    // {
    //     return new QuestItem(QuestItemsScriptableObject.Instance.GetItemInfoByName(name));
    // }

    public enum ItemType
    {
        OTHER,
        USE,
        INGREDIENT,
        BOOK,
        QUEST
    }
}
