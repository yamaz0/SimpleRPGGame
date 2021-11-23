#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
public class ItemsEditorWindow : EditorWindow
{
    CreateItemsEditorWindow createItemsEditorWindow = new CreateItemsEditorWindow();
    ViewItemsEditorWindow viewItemsEditorWindow = new ViewItemsEditorWindow();
    private void OnEnable()
    {
        ItemsScriptableObject.Instance.OnChangedItems += viewItemsEditorWindow.SearchItems;
        DataItemsEditorWindow.instance.ItemInfoTypes = Assembly.GetAssembly(typeof(ItemInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(ItemInfo))).ToList();
    }

    private void OnDisable()
    {
        ItemsScriptableObject.Instance.OnChangedItems -= viewItemsEditorWindow.SearchItems;
    }

    [MenuItem("ProjektMagic/test")]
    private static void ShowWindow()
    {
        ItemsEditorWindow window = GetWindow<ItemsEditorWindow>();
        window.titleContent = new GUIContent("test");
        window.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("clear"))
        {
            ItemsScriptableObject.Instance.Items.ForEach(x => DestroyImmediate(x, true));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            ItemsScriptableObject.Instance.Items.Clear();
            Debug.Log(ItemsScriptableObject.Instance.Items.Count);
        }

        if(GUILayout.Button("Create"))
        {
            DataItemsEditorWindow.instance.ChangeState(DataItemsEditorWindow.State.CREATE);
            DataItemsEditorWindow.instance.ResetSelectedItem();
        }
        if(GUILayout.Button("Show/Hide filtres"))
        {
            DataItemsEditorWindow.instance.IsShowFilter = !DataItemsEditorWindow.instance.IsShowFilter;
        }
        if(DataItemsEditorWindow.instance.IsShowFilter == true)
        {
            createItemsEditorWindow.ShowItemsTypesButtons(viewItemsEditorWindow.ItemTypeFilter);

            if(GUILayout.Button("Change order"))
            {
                DataItemsEditorWindow.instance.ReverseItemList();
            }

            DataItemsEditorWindow.instance.SearchStringField = UnityEditor.EditorGUILayout.TextField(DataItemsEditorWindow.instance.SearchStringField);

            if(GUILayout.Button("Search"))
            {
                DataItemsEditorWindow.instance.SearchString = DataItemsEditorWindow.instance.SearchStringField;
                viewItemsEditorWindow.SearchItems();
            }
        }

        DataItemsEditorWindow.instance.CreateWidth = 300;
        EditorGUIUtility.labelWidth = 80;

        GUILayout.BeginArea(new Rect(Screen.width-DataItemsEditorWindow.instance.CreateWidth,100,DataItemsEditorWindow.instance.CreateWidth,Screen.height));
            switch (DataItemsEditorWindow.instance.CurrentState)
            {
                case DataItemsEditorWindow.State.NONE:
                    DataItemsEditorWindow.instance.CreateWidth=0;
                    break;
                case DataItemsEditorWindow.State.CREATE:
                    createItemsEditorWindow.ShowBackButton();
                    createItemsEditorWindow.ShowCreateItems();
                    break;
                case DataItemsEditorWindow.State.MODIFY:
                    createItemsEditorWindow.Modify();
                    break;
                default:
                    break;
            }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(0,100,Screen.width-DataItemsEditorWindow.instance.CreateWidth,Screen.height));
        viewItemsEditorWindow.ShowItems(DataItemsEditorWindow.instance.Items);
        GUILayout.EndArea();

        if (GUI.Button(new Rect(0,0,Screen.width,Screen.height), "", GUIStyle.none))
        {
            GUI.FocusControl(null);
        }
    }

    public static string TextField(string label, string text)
    {
        var textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
        EditorGUIUtility.labelWidth = textDimensions.x;
        return EditorGUILayout.TextField(label, text);
    }
}
#endif