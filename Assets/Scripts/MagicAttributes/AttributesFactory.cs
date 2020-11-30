using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributesFactory
{
    public static List<ProgressAttribute> GetProgressAttributes()
    {
        return new List<ProgressAttribute>
        {
            new ProgressAttribute(AttributesScriptableObject.MagicAttributes.KNOWLEDGE),
            new ProgressAttribute(AttributesScriptableObject.MagicAttributes.CONCETRATION),
            new ProgressAttribute(AttributesScriptableObject.MagicAttributes.WILL),
            new ProgressAttribute(AttributesScriptableObject.MagicAttributes.MANA)
        };
    }

    public static List<Attribute> GetNormalAttributes()
    {
        return new List<Attribute>
        {
            new Attribute(AttributesScriptableObject.MagicAttributes.KNOWLEDGE),
            new Attribute(AttributesScriptableObject.MagicAttributes.CONCETRATION),
            new Attribute(AttributesScriptableObject.MagicAttributes.WILL),
            new Attribute(AttributesScriptableObject.MagicAttributes.MANA)
        };
    }
}
