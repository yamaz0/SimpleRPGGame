using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsScriptableObject", menuName = "ScriptableObjects/ItemsScriptableObject")]
public class ItemsScriptableObject : SingletonScriptableObject<ItemsScriptableObject>
{
    public ItemInfo GetItemInfoById(int id)
    {
        return (ItemInfo)Objects.GetElementById(id);
    }

    public ItemInfo GetItemInfoByName(string name)
    {
        return (ItemInfo)Objects.GetElementByName(name);
    }

    public List<ItemInfo> GetItemsList()
    {
        List<ItemInfo> items = new List<ItemInfo>(Objects.Count);

        foreach (ItemInfo item in Objects)
        {
            items.Add(item);
        }

        return items;
    }

    private void OnValidate()
    {
        foreach (ItemInfo item in Objects)
        {
            if (item.Icon == null)
                item.Icon = Resources.LoadAll<Sprite>("")[0];
        }
    }

#if UNITY_EDITOR
    public event System.Action OnChangedItems = delegate { };
    public void AddItem(ItemInfo item)
    {
        ItemInfo itemInfoInstance = (ItemInfo)System.Activator.CreateInstance(item.GetType());
        itemInfoInstance.CopyValues(item);

        Objects.Add(itemInfoInstance);
        SaveAndRefresh();
    }

    private void SaveAndRefresh()
    {
        NotifyChangedItemsList();
        UnityEditor.EditorUtility.SetDirty(Instance);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }

    private void NotifyChangedItemsList()
    {
        OnChangedItems();
    }

    public void UpdateItemInstance(ItemInfo item)
    {
        GetItemInfoById(item.Id).CopyValues(item);
        SaveAndRefresh();
    }

    public void RemoveItemInstance(ItemInfo item)
    {
        ItemInfo itemToRemove = GetItemInfoById(item.Id);
        Objects.Remove(itemToRemove);
        // DestroyImmediate(itemToRemove, true);
        SaveAndRefresh();
    }
#endif
}
#if UNITY_EDITOR

[UnityEditor.CustomEditor(typeof(ItemsScriptableObject))]
public class ItemsScriptableObject1Editor : UnityEditor.Editor
{
    List<System.Type> types;
    public ItemsScriptableObject1Editor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(ItemInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(ItemInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (ItemsScriptableObject)target;

        foreach (var t in types)
        {
            string[] typeNames = t.ToString().Split('+');
            if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            {
                ItemInfo item = System.Activator.CreateInstance(t) as ItemInfo;
                item.Id = script.Objects.Count;
                script.Objects.Add(item);
            }
        }
        base.OnInspectorGUI();
    }
}

#endif