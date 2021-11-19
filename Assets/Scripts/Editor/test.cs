using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class test : EditorWindow
{
    enum State
    {
        NONE,
        SHOW_ALL,
        CREATE
    }

    private State currentState = new State();

    [SerializeField]
    private ShowItemsEditorWindow showItemsEditorWindow;
    [SerializeField]
    private CreateItemsEditorWindow createItemsEditorWindow;

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
            currentState = State.SHOW_ALL;
        }
        else if(GUILayout.Button("Create"))
        {
            currentState = State.CREATE;
        }

        switch (currentState)
        {
            case State.NONE:
                break;
            case State.SHOW_ALL:
                ShowItems();
                break;
            case State.CREATE:
                ShowCreateItems();
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
        showItemsEditorWindow.ShowItems();
    }
}
