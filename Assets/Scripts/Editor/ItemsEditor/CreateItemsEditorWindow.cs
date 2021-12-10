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
            DataItemsEditorWindow.instance.ChangeState(DataItemsEditorWindow.State.NONE);
        }
    }

    public void ShowCreateItems()
    {
        ShowBackButton();

        if(DataItemsEditorWindow.instance.CurrentItem == null)
        {
            ShowItemsTypesButtons(DataItemsEditorWindow.instance.CreateItemTypeInstance);
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
                ItemsScriptableObject.Instance.AddItem(DataItemsEditorWindow.instance.CurrentItem);
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

    public void Modify()
    {
        ShowBackButton();

        DataItemsEditorWindow.instance.CurrentItem.ShowFields();

        if (GUILayout.Button("Save"))
        {
            DataItemsEditorWindow.instance.SaveItemInstance();
        }
    }
}
