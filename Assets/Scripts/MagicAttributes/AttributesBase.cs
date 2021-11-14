using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AttributesBase<T> where T : Attribute
{
    [SerializeField]
    private List<T> attributes;

    public List<T> Attributes { get => attributes; set => attributes = value; }

    // public abstract void Init();

    public void AddAttributeLevel(AttributesScriptableObject.MagicAttributes attributeType, int value = 1)
    {
        Attributes[(int)attributeType].AddLevel(value);
    }

    public List<Attribute> GetAttributes()
    {
        return new List<Attribute>(Attributes);
    }
}