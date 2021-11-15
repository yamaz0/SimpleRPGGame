using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [SerializeField]
    private AttributesScriptableObject.MagicAttributes type;
    [SerializeField]
    private int value;

    // public int Id { get => id; set => id = value; }
    public AttributesScriptableObject.MagicAttributes Type { get => type; set => type = value; }
    public int Value { get => value; private set => this.value = value; }

    [field: NonSerialized]
    public event Action<float> OnLevelChanged = delegate { };


    public Attribute(AttributesScriptableObject.MagicAttributes type, int level = 0)
    {
        Type = type;
        Value = level;
    }
    public Attribute(int level = 0)
    {
        Value = level;
    }

    public void AddLevel(int value)
    {
        SetLevel(Value + value);
    }

    public void SetLevel(int value, bool isNotify = true)
    {
        Value = value;

        if(isNotify == true)
        {
            NotifyLevelChanged();
        }
    }

    public void LevelUp()
    {
        Value++;
        NotifyLevelChanged();
    }

    private void NotifyLevelChanged()
    {
        OnLevelChanged(Value);
    }
}
