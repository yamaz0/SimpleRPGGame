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
    private int createWidth = 0;

    private bool isShowFilter = false;
    private bool isShowAllFields = false;
    private string searchString = string.Empty;
    private string searchStringField = string.Empty;
    private System.Type filterType = null;
    private Comparer<ItemInfo> sortedMethod = Comparer<ItemInfo>.Create((x, y) => x.Id.CompareTo(y.Id));
    private bool isSortDescending = false;
    private List<ItemInfo> items = new List<ItemInfo>();

    private List<Type> itemInfoTypes;
    private State currentState = new State();
    private State previusState = new State();
    private ItemInfo currentItem = null;

    private int itemsViewStartY = 110;

    public bool IsShowFilter { get => isShowFilter; set => isShowFilter = value; }
    public string SearchString { get => searchString; set => searchString = value; }
    public string SearchStringField { get => searchStringField; set => searchStringField = value; }
    public List<ItemInfo> Items { get => items; set => items = value; }
    public List<Type> ItemInfoTypes { get => itemInfoTypes; set => itemInfoTypes = value; }
    public State CurrentState { get => currentState; set => currentState = value; }
    public State PreviusState { get => previusState; set => previusState = value; }
    public ItemInfo CurrentItem { get => currentItem; set => currentItem = value; }
    public int CreateWidth { get => createWidth; set => createWidth = value; }
    public int BeginAreaY { get => itemsViewStartY; set => itemsViewStartY = value; }
    public bool IsShowAllFields { get => isShowAllFields; set => isShowAllFields = value; }
    public Type FilterType { get => filterType; set => filterType = value; }
    public Comparer<ItemInfo> SortedMethod { get => sortedMethod; set => sortedMethod = value; }
    public bool IsSortDescending { get => isSortDescending; set => isSortDescending = value; }

    public void ChangeState(State s)
    {
        PreviusState = CurrentState;
        CurrentState = s;
        switch (CurrentState)
        {
            case State.NONE:
                CreateWidth = 0;
                break;
            case State.CREATE:
                CreateWidth = 300;
                break;
            case State.MODIFY:
                CreateWidth = 300;
                break;
            default:
                break;
        }
    }
    public void SetCurrentSelectItem(ItemInfo item)
    {
        CurrentItem = item;
    }

    public void ResetSelectedItem()
    {
        SetCurrentSelectItem(null);
    }

    public void ReverseItemList()
    {
        Items.Reverse();
    }

    public void ShowHideItemFilter()
    {
        IsShowFilter = !IsShowFilter;
        if (IsShowFilter == true)
        {
            BeginAreaY = 220;
        }
        else
        {
            BeginAreaY = 110;
        }
    }

    public void SortItems(Comparer<ItemInfo> comparer)
    {
        sortedMethod = comparer;
        Items.Sort(comparer);

        if (IsSortDescending == true)
        {
            ReverseItemList();
        }
    }

    public void CreateItemTypeInstance(Type t)
    {
        int itemId = ItemsScriptableObject.Instance.Objects.Count > 0 ? ItemsScriptableObject.Instance.Objects[ItemsScriptableObject.Instance.Objects.Count - 1].Id + 1 : 0;

        ItemInfo item = (ItemInfo)System.Activator.CreateInstance(t);
        item.Id = itemId;
        item.Icon = Resources.LoadAll<Sprite>("")[0];

        SetCurrentSelectItem(item);
    }

    public void SaveItemInstance()
    {
        ItemsScriptableObject.Instance.UpdateItemInstance(CurrentItem);
    }

    public void RemoveItem(ItemInfo item)
    {
        if (CurrentItem != null && CurrentItem.Id == item.Id)
        {
            ResetSelectedItem();
            ChangeState(State.NONE);
        }
        ItemsScriptableObject.Instance.RemoveItemInstance(item);
    }

}
