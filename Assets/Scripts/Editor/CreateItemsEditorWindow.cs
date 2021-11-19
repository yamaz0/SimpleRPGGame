using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateItemsEditorWindow : EditorWindow
{
    private int bookXp;
    private Sprite icon;
    private int questId;
    private int id;
    private string nameItem;
    private ItemsManager.ItemType currentType = ItemsManager.ItemType.OTHER;
    private bool hasTypeSelected = false;

    public void ShowItemsCreator()
    {
        if(hasTypeSelected == false)
        {
            ShowItemsTypesButtons();
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                hasTypeSelected = false;
            }

            ShowItemsFields();

            if (GUILayout.Button("ADD"))
            {
                CreateItem();
            }
        }
    }

    private void CreateItem()
    {
        ItemInfo itemInfoInstance = null;
        switch (currentType)
        {
            case ItemsManager.ItemType.OTHER:
                break;
            case ItemsManager.ItemType.USE:
                break;
            case ItemsManager.ItemType.INGREDIENT:
                break;
            case ItemsManager.ItemType.BOOK:
                itemInfoInstance = (ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.BOOK) as BookItemInfo).Init(id, nameItem, icon, bookXp);
                break;
            case ItemsManager.ItemType.QUEST:
                itemInfoInstance = (ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.QUEST) as QuestItemInfo).Init(id, nameItem, icon, questId);
                break;
            default:
                break;
        }

        itemInfoInstance.name = itemInfoInstance.ItemName;
        ItemsScriptableObject.Instance.Items.Add(itemInfoInstance);

        AssetDatabase.AddObjectToAsset(itemInfoInstance,ItemsSO.Instance);
        EditorUtility.SetDirty(ItemsScriptableObject.Instance);
        EditorUtility.SetDirty(itemInfoInstance);
        EditorUtility.SetDirty(ItemsSO.Instance);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void ShowItemsFields()
    {
        if(ItemsScriptableObject.Instance.Items == null)
        {
            ItemsScriptableObject.Instance.Items = new List<ItemInfo>();
        }

        id = ItemsScriptableObject.Instance.Items.Count > 0 ? ItemsScriptableObject.Instance.Items[ItemsScriptableObject.Instance.Items.Count - 1].Id + 1 : 0;
        GUILayout.Label("Id: " + id.ToString());
        nameItem = EditorGUILayout.TextField("Name: ",nameItem);
        icon = (Sprite)EditorGUILayout.ObjectField("Sprite: ",icon,typeof(Sprite));

        switch (currentType)
        {
            case ItemsManager.ItemType.OTHER:
                break;
            case ItemsManager.ItemType.USE:
                break;
            case ItemsManager.ItemType.INGREDIENT:
                break;
            case ItemsManager.ItemType.BOOK:
                bookXp = EditorGUILayout.IntField("BookXp: ", bookXp);
                break;
            case ItemsManager.ItemType.QUEST:
                questId = EditorGUILayout.IntField("QuestId: ", questId);
                break;
            default:
                break;
        }
    }

    private void ShowItemsTypesButtons()
    {
        GUILayout.Label("Item Type");
        GUILayout.BeginHorizontal();
        string[] types = System.Enum.GetNames(typeof(ItemsManager.ItemType));
        foreach (string t in types)
        {
            if (GUILayout.Button(t))
            {
                System.Enum.TryParse(t, out ItemsManager.ItemType enumType);
                currentType = enumType;
                hasTypeSelected = true;
            }
        }
        GUILayout.EndHorizontal();
    }
}
