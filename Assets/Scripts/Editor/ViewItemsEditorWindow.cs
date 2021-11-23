using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewItemsEditorWindow
{

    Vector2 scrollPos;
    bool isShowAll = false;
    public void SearchItems()
    {
        isShowAll = false;
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

    public void ShowItems(List<ItemInfo> items)
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
                            if(isShowAll == true)
                            {
                                item.ShowAllItemInfo();
                            }
                            else
                                item.ShowBaseItemInfo();

                                    GUILayout.BeginHorizontal();
                                    if(GUILayout.Button("Del"))
                                    {
                                        if(DataItemsEditorWindow.instance.CurrentItem != null && DataItemsEditorWindow.instance.CurrentItem.Id == item.Id)
                                        {
                                            DataItemsEditorWindow.instance.ResetSelectedItem();
                                            DataItemsEditorWindow.instance.ChangeState(DataItemsEditorWindow.State.NONE);
                                        }
                                        ItemsScriptableObject.Instance.RemoveItemInstance(item);
                                        break;
                                    }
                                    if(GUILayout.Button("Mod"))
                                    {
                                        DataItemsEditorWindow.instance.ChangeState(DataItemsEditorWindow.State.MODIFY);
                                        ItemInfo itemInfoCopy = (ItemInfo)ScriptableObject.CreateInstance(item.GetType());
                                        itemInfoCopy.CopyValues(item);
                                        DataItemsEditorWindow.instance.CurrentItem = itemInfoCopy;
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

    public void ItemTypeFilter(System.Type t)
    {
        isShowAll = true;
        DataItemsEditorWindow.instance.Items.Clear();
        DataItemsEditorWindow.instance.Items.AddRange(ItemsScriptableObject.Instance.Items.FindAll((x) => x.GetType().Equals(t)));
    }

}
