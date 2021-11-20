using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class test : EditorWindow
{
    public enum State
    {
        NONE,
        SHOW_ALL,
        CREATE,
        MODIFY
    }

    private State currentState = new State();

    [SerializeField]
    private ShowItemsEditorWindow showItemsEditorWindow;
    [SerializeField]
    private CreateItemsEditorWindow createItemsEditorWindow;

    public State CurrentState { get => currentState; set => currentState = value; }

    private void OnEnable()
    {
        showItemsEditorWindow = CreateInstance<ShowItemsEditorWindow>();
        createItemsEditorWindow = CreateInstance<CreateItemsEditorWindow>();
    }

    [MenuItem("ProjektMagic/test")]
    private static void ShowWindow()
    {
        test window = GetWindow<test>();
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

        if(GUILayout.Button("show items"))
        {
            CurrentState = State.SHOW_ALL;
        }
        else if(GUILayout.Button("Create"))
        {
            CurrentState = State.CREATE;
            createItemsEditorWindow.HasTypeSelected = false;
        }

        switch (CurrentState)
        {
            case State.NONE:
                break;
            case State.SHOW_ALL:
                ShowItems();
                break;
            case State.CREATE:
                ShowCreateItems();
                break;
            case State.MODIFY:
                createItemsEditorWindow.ShowItemsModify();
                break;
            default:
                break;
        }
    }

    private void ShowCreateItems()
    {
        createItemsEditorWindow.ShowItemsCreator();
    }

    Vector2 scrollPos;
    private void ShowItems()
    {
        List<ItemInfo> items = ItemsScriptableObject.Instance.Items;

        if (items != null)
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos,false,true);
                GUILayout.BeginVertical();

                int w = 0;
                int h = 0;

                items.ForEach(x =>
                {
                    if(w == 0)
                    {
                        GUILayout.BeginHorizontal();
                    }
                            GUILayout.BeginVertical();
                                GUILayout.BeginArea(new Rect(100*w, 100*h, 200, 200));
                                    GUILayout.Label("Id: " + x.Id.ToString());
                                    GUILayout.Label("Name: " + x.ItemName);
                                    GUILayout.Label("Type: " + x.ItemType.ToString());
                                    GUILayout.Box(x.Icon.texture);
                                    // GUI.DrawTexture(new Rect(0,0,50,50),x.Icon.texture);
                                        // GUILayout.BeginHorizontal();
                                        if(GUILayout.Button("Modify"))
                                        {
                                            createItemsEditorWindow.SetValuesFields(x);
                                            CurrentState = test.State.MODIFY;
                                        }
                                        // GUILayout.EndHorizontal();
                                    GUILayout.Space(10);
                                GUILayout.EndArea();
                            GUILayout.EndVertical();

                        w++;
                        if(w > Screen.width/100-1)
                        {
                            w = 0;
                            h++;
                        GUILayout.EndHorizontal();
                        }
                });

                GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }
    }
}
