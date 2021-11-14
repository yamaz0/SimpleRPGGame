using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressAttributes : AttributesBase<ProgressAttribute>
{
    public ProgressAttributes()
    {
        Attributes = AttributesFactory.GetAttributes<ProgressAttribute>();
    }
}
