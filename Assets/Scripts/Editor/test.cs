using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class test : EditorWindow
{
    enum State
    {
        NONE,
        SHOW_ALL,
        CREATE
    }

    private State currentState = new State();
    private ItemsManager.ItemType currentType = ItemsManager.ItemType.OTHER;

    int bookXp;
    int questId;
    int id;
    string nameItem;
    ItemsScriptableObject.ItemInfo itemInfoInstance;


    [MenuItem("ProjektMagic/test")]
    private static void ShowWindow() {
        test window = GetWindow<test>();
        window.titleContent = new GUIContent("test");
        window.Show();
    }

    private void OnGUI() {

        if (GUILayout.Button("clear"))
        {
            ItemsScriptableObject.Instance.Items.Clear();
            Debug.Log(ItemsScriptableObject.Instance.Items.Count);
        }
        if(GUILayout.Button("show items"))
        {
            currentState = State.SHOW_ALL;
        }
        else if(GUILayout.Button("add"))
        {
            currentState = State.CREATE;
            // if(ItemsScriptableObject.Instance.Items == null)
            // ItemsScriptableObject.Instance.Items = new List<ItemsScriptableObject.ItemInfo>();

            BookItemInfo bookItemInfo = ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.BOOK) as BookItemInfo;
            bookItemInfo.Init(0,"imte",5);
            QuestItemInfo bookItemInfo1 = ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.QUEST) as QuestItemInfo;
            bookItemInfo1.Init(1,"imte2",5);
            BookItemInfo bookItemInfo2 = ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.BOOK) as BookItemInfo;
            bookItemInfo2.Init(2,"imte3",5);
        }

        switch (currentState)
        {
            case State.NONE:
                break;
            case State.SHOW_ALL:
                ShowItems();
                break;
            case State.CREATE:
                ShowCreateItems();
                break;
            default:
                break;
        }




    }

    private void ShowCreateItems()
    {
        ShowItemsTypesButtons();

        GUILayout.BeginVertical();
        ShowItemsCreateFields();
        ShowItemAddButton();
        GUILayout.EndVertical();
    }

    private void ShowItemAddButton()
    {
        if (GUILayout.Button("ADD"))
        {
            switch (currentType)
            {
                case ItemsManager.ItemType.OTHER:
                    break;
                case ItemsManager.ItemType.USE:
                    break;
                case ItemsManager.ItemType.INGREDIENT:
                    break;
                case ItemsManager.ItemType.BOOK:
                    itemInfoInstance = (ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.BOOK) as BookItemInfo).Init(id, nameItem, bookXp);
                    break;
                case ItemsManager.ItemType.QUEST:
                    itemInfoInstance = (ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.QUEST) as QuestItemInfo).Init(id, nameItem, questId);
                    break;
                default:
                    break;
            }
            ItemsScriptableObject.Instance.Items.Add(itemInfoInstance);
        }
    }

    private void ShowItemsCreateFields()
    {
        id = EditorGUILayout.IntField(ItemsScriptableObject.Instance.Items.Count, "id");
        nameItem = EditorGUILayout.TextField(nameItem);
        switch (currentType)
        {
            case ItemsManager.ItemType.OTHER:
                break;
            case ItemsManager.ItemType.USE:
                break;
            case ItemsManager.ItemType.INGREDIENT:
                break;
            case ItemsManager.ItemType.BOOK:
                bookXp = EditorGUILayout.IntField(1);
                break;
            case ItemsManager.ItemType.QUEST:
                questId = EditorGUILayout.IntField(1);
                break;
            default:
                break;
        }
    }

    private void ShowItemsTypesButtons()
    {
        GUILayout.BeginHorizontal();
        string[] types = System.Enum.GetNames(typeof(ItemsManager.ItemType));
        foreach (string t in types)
        {
            if (GUILayout.Button(t))
            {
                System.Enum.TryParse(t, out ItemsManager.ItemType enumType);
                currentType = enumType;
            }
        }
        GUILayout.EndHorizontal();
    }

    private void ShowItems()
    {
        List<ItemsScriptableObject.ItemInfo> items = ItemsScriptableObject.Instance.Items;

        if (items != null)
        {
            GUILayout.BeginVertical();

            items.ForEach(x =>
            {
                GUILayout.Label("Id: " + x.Id.ToString());
                GUILayout.Label("Name: " + x.ItemName);
                GUILayout.Label("Type: " + x.ItemType.ToString());
                GUILayout.Space(10);
            });

            GUILayout.EndVertical();
        }
    }
}
