using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text titleText;
    [SerializeField]
    private TMPro.TMP_Text descText;
    [SerializeField]
    private Button button;

    public Button Button { get => button; set => button = value; }

    public void Init(string title, string desc)
    {
        titleText.SetText(title);
        descText.SetText(desc);
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnOkButtonClick);
    }

    public void OnOkButtonClick()
    {
        gameObject.SetActive(false);
    }
}
