using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    public Item ItemCache { get; set; }

    // public event System.Action OnItemChanged = delegate { };

    public void Init(Item item)
    {
        ItemCache = item;
        icon.sprite = ItemCache.Icon;
    }

    public void RemoveItem()
    {
        // ItemId = Constants.NONE_EQUIP_ID;
        // ItemCache = null;
    }

    public void SetItem(int id)
    {
        // ItemId = id;
        // CreateItemCache();
        // NotifyItemChanged();
    }

    // public void SetItem(ref Item item)
    // {
    //     ItemId = item.Id;
    //     // Item tmp = ItemCache;
    //     // ItemCache = item;
    //     // item = tmp;
    // }

    // private void CreateItemCache()
    // {
    // ItemCache = ItemsScriptableObject.Instance.GetItemInfoById(ItemId).CreateItem();
    // }

    // private void NotifyItemChanged()
    // {
    //     OnItemChanged();
    // }
}