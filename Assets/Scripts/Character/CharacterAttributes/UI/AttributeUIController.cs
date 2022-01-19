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

    public void Init()
    {
        CacheModificator = Player.Instance.Character.Attributes.GetAttribute(AttributeName);
        TextValue.Init(AttributeName, CacheModificator.BaseValue.ToString());
        AttachedEvents();
    }

    public void AttachedEvents()
    {
        if (CacheModificator != null)
        {
            Button.onClick.AddListener(AddValue);
            CacheModificator.OnValueChanged += SetTextValue;
        }
    }

    private void AddValue()
    {
        CacheModificator.AddValue(1, true);
    }

    public void DetachEvents()
    {
        Button.onClick.RemoveListener(AddValue);
        CacheModificator.OnValueChanged -= SetTextValue;
    }

    public void SetTextValue(float value)
    {
        TextValue.SetTextValue(value.ToString());
    }
}
