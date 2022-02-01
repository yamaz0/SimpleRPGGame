using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text titleText;
    [SerializeField]
    private TMPro.TMP_Text descText;

    public void Init(string title, string desc)
    {
        titleText.SetText(title);
        descText.SetText(desc);
    }

    public void OnOkButtonClick()
    {
        gameObject.SetActive(false);
    }
}
