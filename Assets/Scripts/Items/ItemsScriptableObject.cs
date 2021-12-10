using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsScriptableObject", menuName = "ScriptableObjects/ItemsScriptableObject")]
public class ItemsScriptableObject : ScriptableObject
{
    private static ItemsScriptableObject instance;

    [SerializeReference]
    private List<ItemInfo> items;

    public static ItemsScriptableObject Instance { get { if (instance == null) instance = Resources.LoadAll<ItemsScriptableObject>("")[0]; return instance; } }

    public List<ItemInfo> Items { get => items; set => items = value; }

#if UNITY_EDITOR
    public event System.Action OnChangedItems = delegate { };
    public void AddItem(ItemInfo item)
    {
        ItemInfo itemInfoInstance = (ItemInfo)System.Activator.CreateInstance(item.GetType());
        itemInfoInstance.CopyValues(item);

        Items.Add(itemInfoInstance);
        // SaveAndRefresh();
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
        // SaveAndRefresh();
    }

    public void RemoveItemInstance(ItemInfo item)
    {
        ItemInfo itemToRemove = GetItemInfoById(item.Id);
        Items.Remove(itemToRemove);
        // DestroyImmediate(itemToRemove, true);
        // SaveAndRefresh();
    }
#endif

    private void OnEnable()
    {
        instance = Resources.LoadAll<ItemsScriptableObject>("")[0];

        if (Items == null)
        {
            Items = new List<ItemInfo>();
        }

        // hideFlags = HideFlags.HideAndDontSave;
    }

    public ItemInfo GetItemInfoById(int id)
    {
        return Items.GetElementById(id);
    }

    public ItemInfo GetItemInfoByName(string name)
    {
        return Items.GetElementByName(name);
    }
}

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
                script.Items.Add(System.Activator.CreateInstance(t) as ItemInfo);
            }
        }
        base.OnInspectorGUI();
    }
}
