using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int price;
    [SerializeField]
    private ItemsManager.ItemType itemType;

    public ItemsManager.ItemType ItemType { get => itemType; set => itemType = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public int Price { get => price; set => price = value; }

    public virtual Item CreateItem()
    {
        return null;
    }

    public virtual void CopyValues(ItemInfo item)
    {
        Id = item.Id;
        Name = item.Name;
        Icon = item.Icon;
        Price = item.Price;
    }

#if UNITY_EDITOR
    public virtual void ShowFields()
    {
        GUILayout.Label("Id: " + Id.ToString());
        Name = UnityEditor.EditorGUILayout.TextField("Name: ", Name);
        Icon = (Sprite)UnityEditor.EditorGUILayout.ObjectField("Sprite: ", Icon, typeof(Sprite), false);
        Price = UnityEditor.EditorGUILayout.IntField("Price: ", Price);
    }

    public void ShowBaseItemInfo()
    {
        GUILayout.Box(GenerateTextureFromSprite(Icon), GUILayout.Width(100), GUILayout.Height(50));
        GUILayout.Label("Id: " + Id.ToString());
        GUILayout.Label(Name);
        GUILayout.Label("Type: " + ItemType.ToString());
        GUILayout.Label("Price: " + Price.ToString());
    }

    Texture2D GenerateTextureFromSprite(Sprite aSprite)
    {
        var rect = aSprite.rect;
        var tex = new Texture2D((int)rect.width, (int)rect.height);
        var data = aSprite.texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        tex.SetPixels(data);
        tex.Apply(true);
        return tex;
    }

    public virtual void ShowAllItemInfo()
    {
        ShowBaseItemInfo();
    }
#endif
}