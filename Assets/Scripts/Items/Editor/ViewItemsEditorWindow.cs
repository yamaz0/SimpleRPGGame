using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewItemsEditorWindow
{
    Vector2 scrollPos;

    List<ItemInfo> filterList = new List<ItemInfo>();

    public void Init()
    {
        RefreshLists();
    }

    public void RefreshLists()
    {
        ItemTypeFilter(DataItemsEditorWindow.instance.FilterType);
        DataItemsEditorWindow.instance.SortItems(DataItemsEditorWindow.instance.SortedMethod);
    }

    public void SearchItems()
    {
        DataItemsEditorWindow.instance.Items.Clear();
        if (string.IsNullOrEmpty(DataItemsEditorWindow.instance.SearchString) == false)
        {
            DataItemsEditorWindow.instance.Items.AddRange(filterList.FindAll((x) => x.Name.Contains(DataItemsEditorWindow.instance.SearchString)));
        }
        else
        {
            DataItemsEditorWindow.instance.Items.AddRange(filterList);
        }
    }

    public void ShowSortingButtons()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Sort By: ");
        if (GUILayout.Button("ID"))
        {
            DataItemsEditorWindow.instance.SortItems(Comparer<ItemInfo>.Create((x, y) => x.Id.CompareTo(y.Id)));
        }
        if (GUILayout.Button("NAME"))
        {
            DataItemsEditorWindow.instance.SortItems(Comparer<ItemInfo>.Create((x, y) => x.Name.CompareTo(y.Name)));
        }
        if (GUILayout.Button("TYPE"))
        {
            DataItemsEditorWindow.instance.SortItems(Comparer<ItemInfo>.Create((x, y) => x.ItemType.CompareTo(y.ItemType)));
        }
        GUILayout.EndHorizontal();
    }

    public void ShowChangeSortOrder()
    {
        if (GUILayout.Button("Change order"))
        {
            DataItemsEditorWindow.instance.IsSortDescending = !DataItemsEditorWindow.instance.IsSortDescending;
            DataItemsEditorWindow.instance.ReverseItemList();
        }
    }

    public void ShowItems(List<ItemInfo> items)
    {
        if (items != null)
        {
            GUILayout.BeginArea(new Rect(0, DataItemsEditorWindow.instance.BeginAreaY, Screen.width - DataItemsEditorWindow.instance.CreateWidth, Screen.height - 25 - DataItemsEditorWindow.instance.BeginAreaY));
            scrollPos = GUILayout.BeginScrollView(scrollPos,false,true);

            int w = 0;
            int h = 0;
            float expand = DataItemsEditorWindow.instance.IsShowAllFields == true ? 1.2f : 1.0f;

            foreach (var item in items)
            {
                if(w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                        GUILayout.BeginVertical();
                            GUILayout.BeginArea(new Rect(100*w, 150*expand*h, 100, 150));
                            if(DataItemsEditorWindow.instance.IsShowAllFields == true)
                            {
                                item.ShowAllItemInfo();
                            }
                            else
                                item.ShowBaseItemInfo();

                                    GUILayout.BeginHorizontal();
                                    if(GUILayout.Button("Del"))
                                    {
                                        DataItemsEditorWindow.instance.RemoveItem(item);
                                        break;
                                    }
                                    if (GUILayout.Button("Mod"))
                                    {
                                        DataItemsEditorWindow.instance.ChangeState(DataItemsEditorWindow.State.MODIFY);

                                        ItemInfo itemInfoCopy = (ItemInfo)System.Activator.CreateInstance(item.GetType());
                                        itemInfoCopy.CopyValues(item);

                                        DataItemsEditorWindow.instance.SetCurrentSelectItem(itemInfoCopy);
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
            GUILayout.EndArea();
        }
    }

    public void ShowSearch()
    {
        DataItemsEditorWindow.instance.SearchStringField = EditorGUILayout.TextField(DataItemsEditorWindow.instance.SearchStringField);
        if (GUILayout.Button("Search"))
        {
            DataItemsEditorWindow.instance.SearchString = DataItemsEditorWindow.instance.SearchStringField;
            SearchItems();
        }
    }

    public void ItemTypeFilter(System.Type t)
    {
        DataItemsEditorWindow.instance.FilterType = t;
        filterList.Clear();

        if(t == null)
        {
            filterList.AddRange(ItemsScriptableObject.Instance.GetItemsList());
            DataItemsEditorWindow.instance.IsShowAllFields = false;
        }
        else
        {
            filterList.AddRange(ItemsScriptableObject.Instance.GetItemsList().FindAll((x) => x.GetType().Equals(t)));
            DataItemsEditorWindow.instance.IsShowAllFields = true;
        }

        SearchItems();
    }

}
