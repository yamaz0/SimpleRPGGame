using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character<T> where T : Attribute
{
    [SerializeField]
    private AttributesBase<T> attributes;

    public AttributesBase<T> Attributes { get => attributes; set => attributes = value; }

    public List<Attribute> GetAttributes()
    {
        return Attributes.GetAttributes();
    }
}