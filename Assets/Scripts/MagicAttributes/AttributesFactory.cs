using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributesFactory
{
    // public static List<ProgressAttribute> GetProgressAttributes()
    // {
    //     return new List<ProgressAttribute>
    //     {
    //         new ProgressAttribute(AttributesScriptableObject.MagicAttributes.KNOWLEDGE),
    //         new ProgressAttribute(AttributesScriptableObject.MagicAttributes.CONCETRATION),
    //         new ProgressAttribute(AttributesScriptableObject.MagicAttributes.WILL),
    //         new ProgressAttribute(AttributesScriptableObject.MagicAttributes.MANA)
    //     };
    // }

    // public static List<Attribute> GetNormalAttributes()
    // {
    //     return new List<Attribute>
    //     {
    //         new Attribute(AttributesScriptableObject.MagicAttributes.KNOWLEDGE),
    //         new Attribute(AttributesScriptableObject.MagicAttributes.CONCETRATION),
    //         new Attribute(AttributesScriptableObject.MagicAttributes.WILL),
    //         new Attribute(AttributesScriptableObject.MagicAttributes.MANA)
    //     };
    // }

    public static List<T> GetAttributes<T>() where T: Attribute, new()
    {
        List<T> attributesList = new List<T>();

        foreach (AttributesScriptableObject.MagicAttributes attribute in (AttributesScriptableObject.MagicAttributes[]) System.Enum.GetValues(typeof(AttributesScriptableObject.MagicAttributes)))
        {
            attributesList.Add(new T(){Type = attribute});
        }

        return attributesList;
        // return new List<T>
        // {
        //     new T() {Type = AttributesScriptableObject.MagicAttributes.KNOWLEDGE},
        //     new T() {Type = AttributesScriptableObject.MagicAttributes.CONCETRATION},
        //     new T() {Type = AttributesScriptableObject.MagicAttributes.WILL},
        //     new T() {Type = AttributesScriptableObject.MagicAttributes.MANA},
        //     new T() {Type = AttributesScriptableObject.MagicAttributes.ASDASDSDA}
        // };
    }
}