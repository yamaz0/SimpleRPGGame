using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TooltipUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text itemNameText;
    [SerializeField]
    private TMPro.TMP_Text typeText;
    [SerializeField]
    private TMPro.TMP_Text descText;
    [SerializeField]
    private TMPro.TMP_Text priceText;

    public void Init(Item item, Vector3 position)
    {
        transform.position = position;
        itemNameText.SetText(item.Name);
        typeText.SetText(item.Type.ToString());
        descText.SetText(item.GetDescription());
        priceText.SetText(item.Price.ToString());
    }
}
