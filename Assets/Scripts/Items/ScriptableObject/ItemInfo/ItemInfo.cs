using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private ItemsManager.ItemType itemType;

    public ItemsManager.ItemType ItemType { get => itemType; set => itemType = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    public virtual Item CreateItem()
    {
        return null;
    }

    public virtual void CopyValues(ItemInfo item)
    {
        Id = item.Id;
        Name = item.Name;
        icon = item.Icon;
    }

#if UNITY_EDITOR
    public virtual void ShowFields()
    {
        GUILayout.Label("Id: " + Id.ToString());
        Name = UnityEditor.EditorGUILayout.TextField("Name: ", Name);
        Icon = (Sprite)UnityEditor.EditorGUILayout.ObjectField("Sprite: ",Icon,typeof(Sprite),false);
    }

    public void ShowBaseItemInfo()
    {
        GUILayout.Box(Icon.texture,GUILayout.Width(100),GUILayout.Height(50));
        GUILayout.Label("Id: " + Id.ToString());
        GUILayout.Label(Name);
        GUILayout.Label("Type: " + ItemType.ToString());
    }

    public virtual void ShowAllItemInfo()
    {
        ShowBaseItemInfo();
    }
#endif
}