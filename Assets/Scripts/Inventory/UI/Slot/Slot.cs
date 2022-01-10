using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    public Item ItemCache { get; set; }

    public void Init(Item item)
    {
        ItemCache = item;
        if (ItemCache != null)
            icon.sprite = ItemCache.Icon;
        else
            icon.sprite = Resources.LoadAll<Sprite>("")[0];
    }
}