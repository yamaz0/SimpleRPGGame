#if UNITY_EDITOR

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
    private CreateItemsEditorWindow createItemsEditorWindow;

    public State CurrentState { get => currentState; set => currentState = value; }

    private void OnEnable()
    {
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

            int w = 0;
            int h = 0;

            foreach (var x in items)
            {
                if(w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                        GUILayout.BeginVertical();
                            GUILayout.BeginArea(new Rect(100*w, 150*h, 100, 150));
                                x.ShowBaseItemInfo();
                                // GUI.DrawTexture(new Rect(0,0,50,50),x.Icon.texture);
                                    GUILayout.BeginHorizontal();
                                    if(GUILayout.Button("Del"))
                                    {
                                        createItemsEditorWindow.RemoveItem(x);
                                        break;;
                                    }
                                    if(GUILayout.Button("Mod"))
                                    {
                                        createItemsEditorWindow.SetValuesFields(x);
                                        CurrentState = test.State.MODIFY;
                                    }
                                    GUILayout.EndHorizontal();
                            GUILayout.EndArea();
                                GUILayout.Space(150);
                        GUILayout.EndVertical();

                    w++;
                    if(w > Screen.width/100-1)
                    {
                        w = 0;
                        h++;
                    GUILayout.EndHorizontal();
                    }
            };

            GUILayout.EndScrollView();
        }
    }
}
#endif