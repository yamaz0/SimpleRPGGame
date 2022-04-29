using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class AttributeUIController
{
    private const int MULTIPLIER_ATRIBUTE_COST_VALUE = 10;
    [SerializeField]
    [NameDropdown("Attributes")]
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
        CalcCostValue();
        ShowButton(Player.Instance.Character.Statistics.Exp.Value);
        TextValue.Init(AttributeName, CacheModificator.Value.ToString());
        // AttachedEvents();
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
        Character character = Player.Instance.Character;
        PerksManager.Instance.TryAddAllAvaiblePerks(character);
        character.Statistics.Exp.AddValue(-CostValue, true);
        CalcCostValue();
        CacheModificator.AddValue(1, true);
        character.UpdateStatsMod();
    }

    private void CalcCostValue()
    {
        CostValue = CacheModificator.Value * MULTIPLIER_ATRIBUTE_COST_VALUE;
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
