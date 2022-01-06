using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modificator
{
    [SerializeField]
    private float value;
    public float Value { get => value; private set => this.value = value; }

    [field: NonSerialized]
    public event Action<float> OnLevelChanged = delegate { };

    public Modificator(float modValue = 0)
    {
        SetValue(modValue);
    }

    public void AddValue(float modValue)
    {
        SetValue(Value + modValue);
    }

    public void SetValue(float modValue, bool isNotify = true)
    {
        Value = modValue;

        if (isNotify == true)
        {
            NotifyLevelChanged();
        }
    }

    private void NotifyLevelChanged()
    {
        OnLevelChanged(Value);
    }
}