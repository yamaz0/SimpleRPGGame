using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text descriptionText;
    [SerializeField]
    private Image iconImage;

    public void Init(string text, Sprite icon)
    {
        descriptionText.SetText(text);
        if (icon != null)
            iconImage.sprite = icon;
        Destroy(gameObject, 3);
    }
}
