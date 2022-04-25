using TMPro;
using UnityEngine;

[System.Serializable]
public class ItemTooltipUI : TooltipUI
{
    [SerializeField]
    private TMPro.TMP_Text typeText;
    [SerializeField]
    private TMPro.TMP_Text priceText;

    public TMP_Text TypeText { get => typeText; set => typeText = value; }
    public TMP_Text PriceText { get => priceText; set => priceText = value; }

    public void Init(Item item, Vector3 position)
    {
        transform.position = position;
        ItemNameText.SetText(item.Name);
        TypeText.SetText(item.Type.ToString());
        DescText.SetText(item.GetDescription());
        PriceText.SetText(item.Price.ToString());
    }
}
