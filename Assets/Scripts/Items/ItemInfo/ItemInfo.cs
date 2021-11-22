using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private ItemsManager.ItemType itemType;

    public string ItemName { get => itemName; set { itemName = value; name = value; } }
    public int Id { get => id; set => id = value; }
    public ItemsManager.ItemType ItemType { get => itemType; set => itemType = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    private void OnEnable()
    {
        //  hideFlags = HideFlags.HideAndDontSave;
    }
    public virtual void CopyValues(ItemInfo item)
    {
        Id = item.Id;
        ItemName = item.ItemName;
        icon = item.Icon;
    }

#if UNITY_EDITOR
    public virtual void ShowFields()
    {
        GUILayout.Label("Id: " + Id.ToString());
        ItemName = UnityEditor.EditorGUILayout.TextField("Name: ", ItemName);
        Icon = (Sprite)UnityEditor.EditorGUILayout.ObjectField("Sprite: ",Icon,typeof(Sprite),false);
    }

    public void ShowBaseItemInfo()
    {
        GUILayout.Box(Icon.texture,GUILayout.Width(100),GUILayout.Height(50));
        GUILayout.Label("Id: " + Id.ToString());
        GUILayout.Label(ItemName);
        GUILayout.Label("Type: " + ItemType.ToString());
    }

    public virtual void ShowAllItemInfo()
    {
        ShowBaseItemInfo();
    }
#endif
}