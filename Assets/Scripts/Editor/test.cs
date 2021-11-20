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

    private void ShowItems()
    {
        showItemsEditorWindow.ShowItems(createItemsEditorWindow, this);
    }
}
