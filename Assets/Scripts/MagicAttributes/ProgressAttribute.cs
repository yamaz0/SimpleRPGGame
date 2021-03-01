    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressAttribute : Attribute
{
    [SerializeField]
    public Progress progres;
    public ProgressAttribute(AttributesScriptableObject.MagicAttributes id, int level = 0) : base(id, level)
    {
        progres = new Progress();
    }
    public ProgressAttribute() : base()
    {
        progres = new Progress();
    }

}
