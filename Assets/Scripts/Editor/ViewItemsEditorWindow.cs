using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewItemsEditorWindow
{
    Vector2 scrollPos;
    bool isShowAllFields = false;
    List<ItemInfo> filterList = new List<ItemInfo>();

    public void Init()
    {
        ItemTypeFilter(null);
    }

    public void RefreshLists()
    {
        for (int i = filterList.Count - 1; i >= 0 ; i--)
        {
            if(filterList[i] == null)
            {
                filterList.RemoveAt(i);
                break;
            }
        }
        SearchItems();
    }

    public void SearchItems()
    {
        DataItemsEditorWindow.instance.Items.Clear();
        if (string.IsNullOrEmpty(DataItemsEditorWindow.instance.SearchString) == false)
        {
            DataItemsEditorWindow.instance.Items.AddRange(filterList.FindAll((x) => x.ItemName.Contains(DataItemsEditorWindow.instance.SearchString)));
        }
        else
        {
            DataItemsEditorWindow.instance.Items.AddRange(filterList);
        }
    }

    public void SortItems(Comparer<ItemInfo> comparer)
    {
        DataItemsEditorWindow.instance.Items.Sort(comparer);
    }

    public void ShowItems(List<ItemInfo> items)
    {
        if (items != null)
        {
            GUILayout.BeginArea(new Rect(0, DataItemsEditorWindow.instance.BeginAreaY, Screen.width - DataItemsEditorWindow.instance.CreateWidth, Screen.height));
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
                            if(isShowAllFields == true)
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

                                        ItemInfo itemInfoCopy = (ItemInfo)ScriptableObject.CreateInstance(item.GetType());
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
        filterList.Clear();

        if(t == null)
        {
            filterList.AddRange(ItemsScriptableObject.Instance.Items);
            isShowAllFields = false;
        }
        else
        {
            filterList.AddRange(ItemsScriptableObject.Instance.Items.FindAll((x) => x.GetType().Equals(t)));
            isShowAllFields = true;
        }

        SearchItems();
    }

}
