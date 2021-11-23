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

#if UNITY_EDITOR
    public event System.Action OnChangedItems = delegate{};
    public void AddItemInstance(ItemInfo item)
    {
        ItemInfo itemInfoInstance = (ItemInfo)CreateInstance(item.GetType());
        itemInfoInstance.CopyValues(item);
        itemInfoInstance.name = itemInfoInstance.ItemName; ;

        Instance.Items.Add(itemInfoInstance);
        UnityEditor.AssetDatabase.AddObjectToAsset(itemInfoInstance, ItemsSO.Instance);
        SaveAndRefresh();
    }

    private void SaveAndRefresh()
    {
        NotifyChangedItemsList();
        UnityEditor.EditorUtility.SetDirty(ItemsScriptableObject.Instance);
        UnityEditor.EditorUtility.SetDirty(ItemsSO.Instance);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }

    private void NotifyChangedItemsList()
    {
        OnChangedItems();
    }

    public void ModifyItemInstance(ItemInfo item)
    {
        GetItemInfoById(item.Id).CopyValues(item);
        SaveAndRefresh();
    }

    public void RemoveItemInstance(ItemInfo item)
    {
        ItemInfo itemToRemove = GetItemInfoById(item.Id);
        Items.Remove(itemToRemove);
        DestroyImmediate(itemToRemove, true);
        SaveAndRefresh();
    }
#endif

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