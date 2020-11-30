using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTextController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text attributeNameText;
    [SerializeField]
    private TMPro.TMP_Text attributeValueText;

    public void Initialize(Attribute attribute)
    {
        // AttributesScriptableObject.AttributeInfo attributeInfo = AttributesScriptableObject.Instance.GetAttributeInfoById(attribute.Id);//ogolnie tutaj chyba powinna byc lokalizacja jakas wiesz o co chodzi byczku co to oglada ;3

        // attribute.OnLevelChanged += SetAttributeValueText;
        // SetAttributeNameText(attributeInfo.Name);
        // SetAttributeValueText(attribute.Level);
    }

    public void SetAttributeNameText(string name)
    {
        attributeNameText.text = name;
    }

    public void SetAttributeValueText(float value)
    {
        attributeValueText.text = value.ToString();
    }
}
