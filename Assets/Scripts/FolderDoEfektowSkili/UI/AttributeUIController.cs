using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class AttributeUIController
{
    [SerializeField]
    [ModDropdown]
    private string attributeName;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TextValueUI textValue;

    public Button Button { get => button; private set => button = value; }

    public string AttributeName { get => attributeName; private set => attributeName = value; }
    public TextValueUI TextValue { get => textValue; private set => textValue = value; }

    public void Init()
    {
        TextValue.Init(AttributeName, ModificatorsManager.Instance.DictModyficators[AttributeName].Value.ToString());
        // AttachedEvents();
    }

    public void AttachedEvents()
    {
        Button.onClick.AddListener(AddValue);
        ModificatorsManager.Instance.DictModyficators[AttributeName].OnLevelChanged += SetTextValue;
    }

    private void AddValue()
    {
        ModificatorsManager.Instance.DictModyficators[attributeName].AddValue(1);
    }

    public void DetachEvents()
    {
        Button.onClick.RemoveListener(AddValue);
        ModificatorsManager.Instance.DictModyficators[AttributeName].OnLevelChanged -= SetTextValue;
    }

    public void SetTextValue(float value)
    {
        TextValue.SetTextValue(value.ToString());
    }
}
