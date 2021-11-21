using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

public class CreateItemsEditorWindow : EditorWindow
{
    ItemInfo currentItem = null;
    List<Type> types1;

    public ItemInfo CurrentItem { get => currentItem; set => currentItem = value; }

    public void ShowItemsCreator()
    {
        if(CurrentItem == null)
        {
            ShowItemsTypesButtons();
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                CurrentItem = null;
            }

            CurrentItem.ShowFields();

            if (GUILayout.Button("ADD"))
            {
                CreateItem();
                CurrentItem = null;
            }
        }
    }

    public void ShowItemsModify()
    {
        CurrentItem.ShowFields();

        if (GUILayout.Button("Save"))
        {
            AssetSaveAndRefresh();
        }
    }

    public void RemoveItem(ItemInfo itemInfo)
    {
        ItemsScriptableObject.Instance.Items.Remove(itemInfo);
        AssetSaveAndRefresh();
    }

    private void CreateItem()
    {
        ItemInfo itemInfoInstance = ItemsScriptableObject.Instance.CreateItem(CurrentItem);

        ItemsScriptableObject.Instance.Items.Add(itemInfoInstance);
        AssetDatabase.AddObjectToAsset(itemInfoInstance, ItemsSO.Instance);
        AssetSaveAndRefresh();
    }

    private void AssetSaveAndRefresh()
    {
        EditorUtility.SetDirty(ItemsScriptableObject.Instance);
        EditorUtility.SetDirty(ItemsSO.Instance);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void OnEnable() {
        types1 = Assembly.GetAssembly(typeof(ItemInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(ItemInfo))).ToList();
    }

    private void ShowItemsTypesButtons()
    {
        GUILayout.Label("Item Type");
        GUILayout.BeginHorizontal();
        foreach (var t in types1)
        {
            if (GUILayout.Button(t.ToString()))
            {
                int itemId = ItemsScriptableObject.Instance.Items.Count > 0 ? ItemsScriptableObject.Instance.Items[ItemsScriptableObject.Instance.Items.Count - 1].Id + 1 : 0;

                CurrentItem = (ItemInfo)Activator.CreateInstance(t);
                CurrentItem.Id = itemId;
            }
        }
        GUILayout.EndHorizontal();
    }
}
