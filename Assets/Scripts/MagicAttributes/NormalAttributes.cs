using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NormalAttributes : AttributesBase<Attribute>
{
    public NormalAttributes()
    {
        Attributes = AttributesFactory.GetNormalAttributes();
    }
}
