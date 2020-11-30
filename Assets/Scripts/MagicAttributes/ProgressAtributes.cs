using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressAttributes : AttributesBase<ProgressAttribute>
{
    public ProgressAttributes()
    {
        Attributes = AttributesFactory.GetProgressAttributes();
    }

    public void AddProgress(AttributesScriptableObject.MagicAttributes attributeType, int value)
    {
        Attributes[(int)attributeType].progres.AddProgress(value);
    }
}
