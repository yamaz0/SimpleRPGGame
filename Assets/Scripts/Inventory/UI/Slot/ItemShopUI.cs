using UnityEngine;

[System.Serializable]
public class ItemShopUI
{
    [SerializeField]
    private TMPro.TMP_Text itemNameText;
    [SerializeField]
    private TMPro.TMP_Text priceText;

    public void Init(Item item)
    {
        itemNameText.SetText(item.Name);
        priceText.SetText(item.Price.ToString());
    }
}
