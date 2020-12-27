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
    private int level;

    // public int Id { get => id; set => id = value; }
    public AttributesScriptableObject.MagicAttributes Type { get => type; set => type = value; }
    public int Level { get => level; private set => level = value; }

    [field: NonSerialized]
    public event Action<float> OnLevelChanged = delegate { };

    public Attribute(AttributesScriptableObject.MagicAttributes id, int level = 0)
    {
        Type = id;
        Level = level;
    }
    public Attribute(int level = 0)
    {
        Level = level;
    }

    public void AddLevel(int value)
    {
        SetLevel(Level + value);
    }

    public void SetLevel(int value, bool isNotify = true)
    {
        Level = value;

        if(isNotify == true)
        {
            NotifyLevelChanged();
        }
    }

    public void LevelUp()
    {
        Level++;
        NotifyLevelChanged();
    }

    private void NotifyLevelChanged()
    {
        OnLevelChanged(Level);
    }
}
