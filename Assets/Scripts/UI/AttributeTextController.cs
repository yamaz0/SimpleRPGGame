using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTextController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text attributeNameText;
    [SerializeField]
    private TMPro.TMP_Text attributeValueText;
    [SerializeField]
    private TMPro.TMP_Text attributePercentValueText;

    private Attribute cache;

    public void Initialize(Attribute attribute)
    {
        AttributesScriptableObject.AttributeInfo attributeInfo = AttributesScriptableObject.Instance.GetAttributeInfoByType(attribute.Type);//ogolnie tutaj chyba powinna byc lokalizacja jakas wiesz o co chodzi byczku co to oglada ;3
    cache = attribute;
        attribute.OnLevelChanged += SetAttributeValueText;
        string attributeName = attributeInfo != null ? attributeInfo.Name : attribute.Type.ToString();
        SetAttributeNameText(attributeName);
        SetAttributeValueText(attribute.Value);
    }

    public void SetAtributeProgers(string value)
    {
        attributePercentValueText.text = value;
    }
    public void SetAttributeNameText(string name)
    {
        attributeNameText.text = name;
    }

    public void SetAttributeValueText(float value)
    {
        attributeValueText.text = value.ToString();
    }

    public void Detach()
    {
        cache.OnLevelChanged-=SetAttributeValueText;
    }
}
