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
    private void OnEnable()
    {
        ItemsScriptableObject.Instance.OnChangedItems += SearchItems;
        DataItemsEditorWindow.instance.ItemInfoTypes = Assembly.GetAssembly(typeof(ItemInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(ItemInfo))).ToList();
    }

    private void OnDisable()
    {
        ItemsScriptableObject.Instance.OnChangedItems -= SearchItems;
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
            DataItemsEditorWindow.instance.PreviusState = DataItemsEditorWindow.instance.CurrentState;
            DataItemsEditorWindow.instance.CurrentState = DataItemsEditorWindow.State.CREATE;
            ResetSelectedItem();
        }
        if(GUILayout.Button("Show/Hide filtres"))
        {
            DataItemsEditorWindow.instance.IsShowFilter = !DataItemsEditorWindow.instance.IsShowFilter;
        }
        if(DataItemsEditorWindow.instance.IsShowFilter == true)
        {
            ShowItemsTypesButtons(ItemTypeFilter);

            if(GUILayout.Button("Change order"))
            {
                DataItemsEditorWindow.instance.Items.Reverse();
            }

            DataItemsEditorWindow.instance.SearchStringField = UnityEditor.EditorGUILayout.TextField(DataItemsEditorWindow.instance.SearchStringField);
            if(GUILayout.Button("Search"))
            {
                DataItemsEditorWindow.instance.SearchString = DataItemsEditorWindow.instance.SearchStringField;
                SearchItems();
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
                    ShowBackButton();
                    ShowCreateItems();
                    break;
                case DataItemsEditorWindow.State.MODIFY:
                    ShowBackButton();
                    DataItemsEditorWindow.instance.CurrentItem.ShowFields();
                    if (GUILayout.Button("Save"))
                    {
                        ItemsScriptableObject.Instance.ModifyItemInstance(DataItemsEditorWindow.instance.CurrentItem);
                    }
                    break;
                default:
                    break;
            }
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(0,100,Screen.width-DataItemsEditorWindow.instance.CreateWidth,Screen.height));
        ShowItems(DataItemsEditorWindow.instance.Items);
        GUILayout.EndArea();

        if (GUI.Button(new Rect(0,0,Screen.width,Screen.height), "", GUIStyle.none))
        {
            GUI.FocusControl(null);
        }
    }

    private void SearchItems()
    {
        DataItemsEditorWindow.instance.Items.Clear();
        if (string.IsNullOrEmpty(DataItemsEditorWindow.instance.SearchString) == false)
        {
            DataItemsEditorWindow.instance.Items.AddRange(ItemsScriptableObject.Instance.Items.FindAll((x) => x.ItemName.Contains(DataItemsEditorWindow.instance.SearchString)));
        }
        else
        {
            DataItemsEditorWindow.instance.Items.AddRange(ItemsScriptableObject.Instance.Items);
        }
    }

    private void ShowBackButton()
    {
        if (GUILayout.Button("X",GUILayout.Width(50)))
        {
            DataItemsEditorWindow.instance.CurrentState = DataItemsEditorWindow.State.NONE;
        }
    }

    private void ShowCreateItems()
    {
        if(DataItemsEditorWindow.instance.CurrentItem == null)
        {
            ShowItemsTypesButtons(CreateItemTypeInstance);
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                ResetSelectedItem();
                return;
            }

            DataItemsEditorWindow.instance.CurrentItem.ShowFields();

            if (GUILayout.Button("ADD"))
            {
                ItemsScriptableObject.Instance.AddItemInstance(DataItemsEditorWindow.instance.CurrentItem);
                ResetSelectedItem();
            }
        }
        // createItemsEditorWindow.ShowItemsCreator();
    }

    private void ResetSelectedItem()
    {
        DataItemsEditorWindow.instance.CurrentItem = null;
    }

    Vector2 scrollPos;
    private void ShowItems(List<ItemInfo> items)
    {
        if (items != null)
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos,false,true);

            int w = 0;
            int h = 0;

            foreach (var item in items)
            {
                if(w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                        GUILayout.BeginVertical();
                            GUILayout.BeginArea(new Rect(100*w, 150*h, 100, 150));
                                item.ShowBaseItemInfo();
                                // GUI.DrawTexture(new Rect(0,0,50,50),x.Icon.texture);
                                    GUILayout.BeginHorizontal();
                                    if(GUILayout.Button("Del"))
                                    {
                                        if(DataItemsEditorWindow.instance.CurrentItem != null && DataItemsEditorWindow.instance.CurrentItem.Id == item.Id)
                                        {
                                            ResetSelectedItem();
                                            DataItemsEditorWindow.instance.CurrentState = DataItemsEditorWindow.State.NONE;
                                        }
                                        ItemsScriptableObject.Instance.RemoveItemInstance(item);
                                        break;
                                    }
                                    if(GUILayout.Button("Mod"))
                                    {
                                        DataItemsEditorWindow.instance.CurrentState = DataItemsEditorWindow.State.MODIFY;
                                        DataItemsEditorWindow.instance.CurrentItem = (ItemInfo)CreateInstance(item.GetType());
                                        DataItemsEditorWindow.instance.CurrentItem.CopyValues(item);
                                    }
                                    GUILayout.EndHorizontal();
                            GUILayout.EndArea();
                            GUILayout.Space(150);
                        GUILayout.EndVertical();

                    w++;
                    if(w > (Screen.width-DataItemsEditorWindow.instance.CreateWidth-10)/100-1)
                    {
                        w = 0;
                        h++;
                    GUILayout.EndHorizontal();
                    }
            };

            GUILayout.EndScrollView();
        }
    }

    private void ShowItemsTypesButtons(Action<Type> OnButtonTypeClicked)
    {
        GUILayout.Label("Items Types");
        GUILayout.BeginHorizontal();
        foreach (var t in DataItemsEditorWindow.instance.ItemInfoTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                OnButtonTypeClicked(t);
            }
        }
        GUILayout.EndHorizontal();
    }

    private void CreateItemTypeInstance(Type t)
    {
        int itemId = ItemsScriptableObject.Instance.Items.Count > 0 ? ItemsScriptableObject.Instance.Items[ItemsScriptableObject.Instance.Items.Count - 1].Id + 1 : 0;

        DataItemsEditorWindow.instance.CurrentItem = (ItemInfo)CreateInstance(t);
        DataItemsEditorWindow.instance.CurrentItem.Id = itemId;
        DataItemsEditorWindow.instance.CurrentItem.Icon = Resources.LoadAll<Sprite>("")[0];
    }

    private void ItemTypeFilter(Type t)
    {
        DataItemsEditorWindow.instance.Items.Clear();
        DataItemsEditorWindow.instance.Items.AddRange(ItemsScriptableObject.Instance.Items.FindAll((x) => x.GetType().Equals(t)));
    }

    public static string TextField(string label, string text)
    {
        var textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
        EditorGUIUtility.labelWidth = textDimensions.x;
        return EditorGUILayout.TextField(label, text);
    }
}
#endif