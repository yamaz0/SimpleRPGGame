using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class AttributeUIController
{
    [SerializeField]
    [ModDropdown("Attributes")]
    private string attributeName;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TextValueUI textValue;

    public Button Button { get => button; private set => button = value; }

    public string AttributeName { get => attributeName; private set => attributeName = value; }
    public TextValueUI TextValue { get => textValue; private set => textValue = value; }

    public Modificator CacheModificator { get; private set; }
    public float CostValue { get; set; }

    public void Init()
    {
        CacheModificator = Player.Instance.Character.Attributes.GetAttribute(AttributeName);
        CostValue = CacheModificator.Value * 100;
        ShowButton(Player.Instance.Character.Statistics.Exp.Value);
        TextValue.Init(AttributeName, CacheModificator.Value.ToString());
        AttachedEvents();
    }

    public void AttachedEvents()
    {
        if (CacheModificator != null)
        {
            Player.Instance.Character.Statistics.Exp.OnValueChanged += ShowButton;
            Button.onClick.AddListener(AddValue);
            CacheModificator.OnValueChanged += SetTextValue;
        }
    }

    private void ShowButton(float value)
    {
        bool isEnough = value >= CostValue;
        Button.gameObject.SetActive(isEnough);

    }
    private void AddValue()
    {
        Player.Instance.Character.Statistics.Exp.AddValue(-CostValue, true);
        CostValue = CacheModificator.Value * 100;
        CacheModificator.AddValue(1, true);
        Debug.Log(Player.Instance.Character.Statistics.Exp.Value);
    }

    public void DetachEvents()
    {
        Player.Instance.Character.Statistics.Exp.OnValueChanged -= ShowButton;
        Button.onClick.RemoveListener(AddValue);
        CacheModificator.OnValueChanged -= SetTextValue;
    }

    public void SetTextValue(float value)
    {
        TextValue.SetTextValue(value.ToString());
    }
}
