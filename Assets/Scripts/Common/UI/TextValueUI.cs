using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextValueUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private TMPro.TMP_Text valueText;

    public TMPro.TMP_Text NameText { get => nameText; private set => nameText = value; }
    public TMPro.TMP_Text ValueText { get => valueText; private set => valueText = value; }

    public void Init(string name, string value)
    {
        SetTextName(name);
        SetTextValue(value);
    }

    public void SetTextValue(float value)
    {
        SetTextValue(value.ToString("N0"));
    }

    public void SetTextValue(string value)
    {
        ValueText.SetText(value);
    }

    public void SetTextName(string name)
    {
        NameText.SetText(name);
    }
}
