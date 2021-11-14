using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class test : EditorWindow {

    [MenuItem("ProjektMagic/test")]
    private static void ShowWindow() {
        test window = GetWindow<test>();
        window.titleContent = new GUIContent("test");
        window.Show();
    }

    private void OnGUI() {

        if(GUILayout.Button("show"))
        {
            // if(ItemsScriptableObject.Instance.Items == null)
            //     ItemsScriptableObject.Instance.Items = new List<ItemsScriptableObject.ItemInfo>();


            // BookItemInfo bookItem = ItemsScriptableObject.Instance.Items[0] as BookItemInfo;
            // Debug.Log(bookItem.BookXp +"exp");


            ItemsScriptableObject.Instance.Items.ForEach(x =>
            {
                if(x != null)
                x.show();
                else
                Debug.Log("null");
            });

            Debug.Log(ItemsScriptableObject.Instance.Items.Count);
        }

        if(GUILayout.Button("clear"))
        {
            ItemsScriptableObject.Instance.Items.Clear();
            Debug.Log(ItemsScriptableObject.Instance.Items.Count);
        }

        if(GUILayout.Button("add"))
        {
            BookItemInfo item = new BookItemInfo();
            BookItemInfo item2 = new BookItemInfo();
            QuestItemInfo item1 = new QuestItemInfo();
            item.BookXp = 5;
            item1.QuestId=2;
            item2.BookXp=1;

            // if(ItemsScriptableObject.Instance.Items == null)
            // ItemsScriptableObject.Instance.Items = new List<ItemsScriptableObject.ItemInfo>();

            ItemsScriptableObject.Instance.AddItem(item);
            ItemsScriptableObject.Instance.AddItem(item2);
            ItemsScriptableObject.Instance.AddItem(item1);
            Debug.Log("dodano 3 itemy");
        }
    }
}
