using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class test : EditorWindow
{
    bool showItem = false;

    [MenuItem("ProjektMagic/test")]
    private static void ShowWindow() {
        test window = GetWindow<test>();
        window.titleContent = new GUIContent("test");
        window.Show();
    }

    private void OnGUI() {

        if(GUILayout.Button("show items"))
        {
            showItem =! showItem;
        }

        if(showItem == true)
        {
            GUILayout.BeginVertical();
            List<ItemsScriptableObject.ItemInfo> items = ItemsScriptableObject.Instance.Items;

            if (items != null)
            {
                items.ForEach(x =>
                {
                    GUILayout.Label(x.Id.ToString());
                    GUILayout.Label(x.ItemName);
                    GUILayout.Label(x.ItemType.ToString());
                });
            }

            GUILayout.EndVertical();
        }

        if(GUILayout.Button("clear"))
        {
            ItemsScriptableObject.Instance.Items.Clear();
            Debug.Log(ItemsScriptableObject.Instance.Items.Count);
        }

        if(GUILayout.Button("add"))
        {
            // if(ItemsScriptableObject.Instance.Items == null)
            // ItemsScriptableObject.Instance.Items = new List<ItemsScriptableObject.ItemInfo>();

            BookItemInfo bookItemInfo = ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.BOOK) as BookItemInfo;
            bookItemInfo.Init(0,"imte",5);
            QuestItemInfo bookItemInfo1 = ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.QUEST) as QuestItemInfo;
            bookItemInfo1.Init(1,"imte2",5);
            BookItemInfo bookItemInfo2 = ItemsScriptableObject.Instance.CreateItem(ItemsManager.ItemType.BOOK) as BookItemInfo;
            bookItemInfo2.Init(2,"imte3",5);
        }
    }
}
