using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attributes
{
    [SerializeField]
    private List<Attribute> attributesList = new List<Attribute>
        {
            new Attribute(AttributesScriptableObject.MagicAttributes.KNOWLEDGE),
            new Attribute(AttributesScriptableObject.MagicAttributes.CONCETRATION),
            new Attribute(AttributesScriptableObject.MagicAttributes.WILL),
            new Attribute(AttributesScriptableObject.MagicAttributes.MANA)
        };

    public List<Attribute> AttributesList { get => attributesList; set => attributesList = value; }

    public void AddAttributeLevel(AttributesScriptableObject.MagicAttributes attributeType, int value = 1)
    {
        AttributesList[(int)attributeType].AddLevel(value);
    }
}