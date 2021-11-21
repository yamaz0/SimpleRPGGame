using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsScriptableObject", menuName = "ScriptableObjects/ItemsScriptableObject")]
public class ItemsScriptableObject: ScriptableObject
{
    private static ItemsScriptableObject instance;

    [SerializeReference]
    private List<ItemInfo> items;

    public static ItemsScriptableObject Instance { get { if(instance == null) instance = Resources.LoadAll<ItemsScriptableObject>("")[0]; return instance; } }

    public List<ItemInfo> Items { get => items; set => items = value; }

    public ItemInfo CreateItem(ItemInfo item)
    {
        ItemInfo itemInfoInstance = null;

        switch (item.ItemType)
        {
            case ItemsManager.ItemType.OTHER:
                break;
            case ItemsManager.ItemType.USE:
                break;
            case ItemsManager.ItemType.INGREDIENT:
                break;
            case ItemsManager.ItemType.BOOK:
                itemInfoInstance = CreateInstance<BookItemInfo>() ;
                break;
            case ItemsManager.ItemType.QUEST:
                itemInfoInstance = CreateInstance<QuestItemInfo>();
                break;
            default:
                Debug.LogError("Error item type.");
                break;
        }

        itemInfoInstance.CopyValues(item);
        itemInfoInstance.name = itemInfoInstance.ItemName;
        return itemInfoInstance;
        // AddObjectToAsset
    }

    private void OnEnable()
    {
        instance = Resources.LoadAll<ItemsScriptableObject>("")[0];

        if(Items == null)
        {
            Items = new List<ItemInfo>();
        }

        // hideFlags = HideFlags.HideAndDontSave;
    }

    public ItemInfo GetItemInfoById(int id)
    {
        foreach (ItemInfo nameInfo in Items)
        {
            if (nameInfo.Id == id)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public ItemInfo GetItemInfoByName(string name)
    {
        foreach (ItemInfo nameInfo in Items)
        {
            if (nameInfo.ItemName == name)
            {
                return nameInfo;
            }
        }

        return null;
    }
}