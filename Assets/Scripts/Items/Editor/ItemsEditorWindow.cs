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
        viewItemsEditorWindow.Init();
        ItemsScriptableObject.Instance.OnChangedItems += viewItemsEditorWindow.RefreshLists;
        DataItemsEditorWindow.instance.ItemInfoTypes = Assembly.GetAssembly(typeof(ItemInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(ItemInfo))).ToList();
    }

    private void OnDisable()
    {
        ItemsScriptableObject.Instance.OnChangedItems -= viewItemsEditorWindow.RefreshLists;
    }

    [MenuItem("ProjektMagic/ItemsEditor")]
    private static void ShowWindow()
    {
        ItemsEditorWindow window = GetWindow<ItemsEditorWindow>();
        window.titleContent = new GUIContent("ItemsEditor");
        window.Show();
    }

    private void OnGUI()
    {
        // if (GUILayout.Button("clear"))
        // {
        //     // ItemsScriptableObject.Instance.Items.ForEach(x => DestroyImmediate(x, true));
        //     AssetDatabase.SaveAssets();
        //     AssetDatabase.Refresh();
        //     ItemsScriptableObject.Instance.Objects.Clear();
        // }

        if (GUILayout.Button("Create"))
        {
            DataItemsEditorWindow.instance.ChangeState(DataItemsEditorWindow.State.CREATE);
            DataItemsEditorWindow.instance.ResetSelectedItem();
        }

        viewItemsEditorWindow.ShowSearch();

        if (GUILayout.Button("Show/Hide filtres"))
        {
            DataItemsEditorWindow.instance.ShowHideItemFilter();
        }
        if (DataItemsEditorWindow.instance.IsShowFilter == true)
        {
            createItemsEditorWindow.ShowItemsTypesButtons(viewItemsEditorWindow.ItemTypeFilter);
            if (GUILayout.Button("ALL"))
            {
                viewItemsEditorWindow.ItemTypeFilter(null);
            }
            viewItemsEditorWindow.ShowChangeSortOrder();

            viewItemsEditorWindow.ShowSortingButtons();
        }

        EditorGUIUtility.labelWidth = 80;

        GUILayout.BeginArea(new Rect(Screen.width - DataItemsEditorWindow.instance.CreateWidth, DataItemsEditorWindow.instance.BeginAreaY, DataItemsEditorWindow.instance.CreateWidth, Screen.height));
        switch (DataItemsEditorWindow.instance.CurrentState)
        {
            case DataItemsEditorWindow.State.NONE:
                break;
            case DataItemsEditorWindow.State.CREATE:
                createItemsEditorWindow.ShowCreateItems();
                break;
            case DataItemsEditorWindow.State.MODIFY:
                createItemsEditorWindow.Modify();
                break;
            default:
                break;
        }
        GUILayout.EndArea();

        viewItemsEditorWindow.ShowItems(DataItemsEditorWindow.instance.Items);

        if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", GUIStyle.none))
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