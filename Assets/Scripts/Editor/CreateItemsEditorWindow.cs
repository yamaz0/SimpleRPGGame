using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

public class CreateItemsEditorWindow
{
    public void ShowBackButton()
    {
        if (GUILayout.Button("X",GUILayout.Width(50)))
        {
            DataItemsEditorWindow.instance.CurrentState = DataItemsEditorWindow.State.NONE;
        }
    }

    public void ShowCreateItems()
    {
        if(DataItemsEditorWindow.instance.CurrentItem == null)
        {
            ShowItemsTypesButtons(CreateItemTypeInstance);
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                DataItemsEditorWindow.instance.ResetSelectedItem();
                return;
            }

            DataItemsEditorWindow.instance.CurrentItem.ShowFields();

            if (GUILayout.Button("ADD"))
            {
                ItemsScriptableObject.Instance.AddItemInstance(DataItemsEditorWindow.instance.CurrentItem);
                DataItemsEditorWindow.instance.ResetSelectedItem();
            }
        }
        // createItemsEditorWindow.ShowItemsCreator();
    }


    public void ShowItemsTypesButtons(Action<Type> OnButtonTypeClicked)
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


    public void CreateItemTypeInstance(Type t)
    {
        int itemId = ItemsScriptableObject.Instance.Items.Count > 0 ? ItemsScriptableObject.Instance.Items[ItemsScriptableObject.Instance.Items.Count - 1].Id + 1 : 0;

        DataItemsEditorWindow.instance.CurrentItem = (ItemInfo)ScriptableObject.CreateInstance(t);
        DataItemsEditorWindow.instance.CurrentItem.Id = itemId;
        DataItemsEditorWindow.instance.CurrentItem.Icon = Resources.LoadAll<Sprite>("")[0];
    }

    public void Modify()
    {
        ShowBackButton();
        DataItemsEditorWindow.instance.CurrentItem.ShowFields();
        if (GUILayout.Button("Save"))
        {
            ItemsScriptableObject.Instance.ModifyItemInstance(DataItemsEditorWindow.instance.CurrentItem);
        }
    }
}
