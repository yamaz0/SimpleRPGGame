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
    public enum State
    {
        NONE,
        CREATE,
        MODIFY
    }

    List<Type> itemInfoTypes;
    private State currentState = new State();
    private State previusState = new State();
    private ItemInfo currentItem = null;
    // [SerializeField]
    // private CreateItemsEditorWindow createItemsEditorWindow;
    int createWidth=300;

    public State CurrentState { get => currentState; set => currentState = value; }
    public ItemInfo CurrentItem { get => currentItem; set => currentItem = value; }

    private void OnEnable()
    {
        // createItemsEditorWindow = CreateInstance<CreateItemsEditorWindow>();
        itemInfoTypes = Assembly.GetAssembly(typeof(ItemInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(ItemInfo))).ToList();
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

        // if(GUILayout.Button("show items"))
        // {
        //     previusState = CurrentState;
        //     CurrentState = State.SHOW_ALL;
        // }
        else if(GUILayout.Button("Create"))
        {
            previusState = CurrentState;
            CurrentState = State.CREATE;
            ResetSelectedItem();
        }
        createWidth=300;
        EditorGUIUtility.labelWidth = 80;
        GUILayout.BeginArea(new Rect(Screen.width-createWidth,100,createWidth,Screen.height));
            switch (CurrentState)
            {
                case State.NONE:
                createWidth=0;
                    break;
                case State.CREATE:
                    ShowBackButton();
                    ShowCreateItems();
                    break;
                case State.MODIFY:
                    ShowBackButton();
                    CurrentItem.ShowFields();
                    if (GUILayout.Button("Save"))
                    {
                        ItemsScriptableObject.Instance.GetItemInfoById(CurrentItem.Id).CopyValues(CurrentItem);
                    }
                    break;
                default:
                    break;
            }
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(0,100,Screen.width-createWidth,Screen.height));
        ShowItems();
        GUILayout.EndArea();

        if (GUI.Button(new Rect(0,0,Screen.width,Screen.height), "", GUIStyle.none))
        {
            GUI.FocusControl(null);
        }
    }

    private void ShowBackButton()
    {
        if (GUILayout.Button("X",GUILayout.Width(50)))
        {
            CurrentState = State.NONE;
        }
    }

    private void ShowCreateItems()
    {
        if(CurrentItem == null)
        {
            ShowItemsTypesButtons();
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                ResetSelectedItem();
                return;
            }

            CurrentItem.ShowFields();

            if (GUILayout.Button("ADD"))
            {
                ItemsScriptableObject.Instance.AddItemInstance(CurrentItem);
                ResetSelectedItem();
            }
        }
        // createItemsEditorWindow.ShowItemsCreator();
    }

    private void ResetSelectedItem()
    {
        CurrentItem = null;
    }

    Vector2 scrollPos;
    private void ShowItems()
    {
        List<ItemInfo> items = ItemsScriptableObject.Instance.Items;
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
                                        ItemsScriptableObject.Instance.RemoveItemInstance(item);
                                        break;
                                    }
                                    if(GUILayout.Button("Mod"))
                                    {
                                        CurrentState = ItemsEditorWindow.State.MODIFY;
                                        CurrentItem = (ItemInfo)CreateInstance(item.GetType());
                                        CurrentItem.CopyValues(item);
                                    }
                                    GUILayout.EndHorizontal();
                            GUILayout.EndArea();
                            GUILayout.Space(150);
                        GUILayout.EndVertical();

                    w++;
                    if(w > (Screen.width-createWidth-10)/100-1)
                    {
                        w = 0;
                        h++;
                    GUILayout.EndHorizontal();
                    }
            };

            GUILayout.EndScrollView();
        }
    }

    private void ShowItemsTypesButtons()
    {
        GUILayout.Label("Item Type");
        GUILayout.BeginHorizontal();
        foreach (var t in itemInfoTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                int itemId = ItemsScriptableObject.Instance.Items.Count > 0 ? ItemsScriptableObject.Instance.Items[ItemsScriptableObject.Instance.Items.Count - 1].Id + 1 : 0;

                CurrentItem = (ItemInfo)CreateInstance(t);
                CurrentItem.Id = itemId;
                CurrentItem.Icon = Resources.LoadAll<Sprite>("")[0];
            }
        }
        GUILayout.EndHorizontal();
    }

  public static string TextField(string label, string text)
  {
    var textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
    EditorGUIUtility.labelWidth = textDimensions.x;
    return EditorGUILayout.TextField(label, text);
  }
}
#endif