using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

[CreateAssetMenu(fileName = "DataItemsEditorWindow", menuName = "ScriptableObjects/DataItemsEditorWindow")]
public class DataItemsEditorWindow : ScriptableSingleton<DataItemsEditorWindow>
{
    public enum State
    {
        NONE,
        CREATE,
        MODIFY
    }

    [SerializeField]
    private int createWidth = 300;

    private bool isShowFilter = false;
    private string searchString = string.Empty;
    private string searchStringField = string.Empty;
    private List<ItemInfo> items = new List<ItemInfo>();

    private List<Type> itemInfoTypes;
    private State currentState = new State();
    private State previusState = new State();
    private ItemInfo currentItem = null;

    public bool IsShowFilter { get => isShowFilter; set => isShowFilter = value; }
    public string SearchString { get => searchString; set => searchString = value; }
    public string SearchStringField { get => searchStringField; set => searchStringField = value; }
    public List<ItemInfo> Items { get => items; set => items = value; }
    public List<Type> ItemInfoTypes { get => itemInfoTypes; set => itemInfoTypes = value; }
    public State CurrentState { get => currentState; set => currentState = value; }
    public State PreviusState { get => previusState; set => previusState = value; }
    public ItemInfo CurrentItem { get => currentItem; set => currentItem = value; }
    public int CreateWidth { get => createWidth; set => createWidth = value; }
}
