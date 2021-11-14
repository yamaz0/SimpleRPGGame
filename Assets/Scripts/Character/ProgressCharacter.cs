using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressCharacter : Character<ProgressAttribute>
{
    public ProgressCharacter()
    {
        Attributes = new ProgressAttributes();
    }

    public void AddProgress(AttributesScriptableObject.MagicAttributes attributeType, int value)
    {
        Attributes.Attributes[(int)attributeType].AddProgress(value);
    }
}