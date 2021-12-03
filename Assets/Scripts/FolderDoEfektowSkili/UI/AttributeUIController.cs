using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class AttributeUIController
{
    [SerializeField]
    [ModDropdownAttribute]
    private string attributeName;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TMPro.TMP_Text attributeNameText;
    [SerializeField]
    private TMPro.TMP_Text attributeValueText;

    public Button Button { get => button; private set => button = value; }
    public TMPro.TMP_Text AttributeNameText { get => attributeNameText; private set => attributeNameText = value; }
    public TMPro.TMP_Text AttributeValueText { get => attributeValueText; private set => attributeValueText = value; }

    public string Attributename { get => attributeName; set => attributeName = value; }

    public void Init()
    {
        AttributeNameText.text = Attributename;
        AttributeValueText.text = ModificatorsManager.Instance.DictModyficators[attributeName].Value.ToString();
        ModificatorsManager.Instance.DictModyficators[attributeName].OnLevelChanged += SetValue;
        Button.onClick.AddListener(AddValue);
    }

    private void AddValue()
    {
        ModificatorsManager.Instance.DictModyficators[attributeName].AddValue(1);
    }

    private void OnDisable() {
    Button.onClick.RemoveListener(AddValue);
}
    public void SetValue(float value)
    {
        AttributeValueText.text = value.ToString();
    }
}
