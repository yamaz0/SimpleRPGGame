using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModificatorInfo
{
    [SerializeField]
    private string propertyName;
    [SerializeField]
    private string nestesPropertyClass;

    public string PropertyName { get => propertyName; set => propertyName = value; }
    public string NestesPropertyClassName { get => nestesPropertyClass; set => nestesPropertyClass = value; }

    public void Init(string name, string nestedName)
    {
        PropertyName = name;
        NestesPropertyClassName = nestedName;
    }
}