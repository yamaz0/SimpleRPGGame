using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemsScriptableObject")]
public class ItemsScriptableObject: ScriptableObject
{
    private static ItemsScriptableObject instance;

    private List<ItemsScriptableObject.ItemInfo> items = new List<ItemInfo>();

    public static ItemsScriptableObject Instance { get { return instance; } }

    public List<ItemsScriptableObject.ItemInfo> Items { get => items; set => items = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<ItemsScriptableObject>("")[0];
    }

    public ItemsScriptableObject()
    {
        instance = this;
    }

    public void AddItem(ItemInfo item)
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
                 itemInfoInstance = CreateInstance<BookItemInfo>();
                break;
            case ItemsManager.ItemType.QUEST:
                itemInfoInstance = CreateInstance<QuestItemInfo>();
                break;
            default:
                Debug.LogError("Error item type.");
                return;
        }

        Items.Add(itemInfoInstance);
        Debug.Log(Items.Count);
        // AddObjectToAsset
    }

    private void OnEnable()
    {
        if(Items == null)
        {
            Items = new List<ItemInfo>();
        }

        hideFlags = HideFlags.HideAndDontSave;
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

    [System.Serializable]
    public class ItemInfo : ScriptableObject
    {
        [SerializeField]
        private string itemName;
        [SerializeField]
        private int id;
        [SerializeField]
        private ItemsManager.ItemType itemType;//prawdopodobnie do wywalenia xd

        public string ItemName { get => itemName; set => itemName = value; }
        public int Id { get => id; set => id = value; }
        public ItemsManager.ItemType ItemType { get => itemType; set => itemType = value; }

    private void OnEnable()
    {
        hideFlags = HideFlags.HideAndDontSave;
    }
        public virtual void show()
        {
Debug.Log("nie tutaj");
        }
    }
}