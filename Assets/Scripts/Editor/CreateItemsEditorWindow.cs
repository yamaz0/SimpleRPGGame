// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System.Reflection;
// using System;
// using System.Linq;

// public class CreateItemsEditorWindow : EditorWindow
// {

//     public void ShowItemsCreator()
//     {

//     }

//     public void ShowItemsModify()
//     {
//         CurrentItem.ShowFields();

//         if (GUILayout.Button("Save"))
//         {
//             AssetSaveAndRefresh();
//         }
//     }

//     public void RemoveItem(ItemInfo itemInfo)
//     {
//         ItemsScriptableObject.Instance.Items.Remove(itemInfo);
//         AssetSaveAndRefresh();
//     }

//     public void CreateItemInstance(ItemInfo item)
//     {
//         ItemInfo itemInfoInstance = ItemsScriptableObject.Instance.CreateItemInstance(item);

//         ItemsScriptableObject.Instance.Items.Add(itemInfoInstance);
//         AssetDatabase.AddObjectToAsset(itemInfoInstance, ItemsSO.Instance);
//         AssetSaveAndRefresh();
//     }


// }
