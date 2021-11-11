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

    public Attribute GetAttribute(AttributesScriptableObject.MagicAttributes type)
    {
        return AttributesList[(int)type];
    }

    public void AddAttributeLevel(AttributesScriptableObject.MagicAttributes type, int value = 1)
    {
        AttributesList[(int)type].AddLevel(value);
    }
}
