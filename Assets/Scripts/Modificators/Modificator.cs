using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modificator
{
    [SerializeField]
    private float baseValue;
    public float BaseValue { get => baseValue; private set => baseValue = value; }
    public float TmpValue { get; private set; }
    public float Value { get => BaseValue + TmpValue; }

    [field: NonSerialized]
    public event Action<float> OnValueChanged = delegate { };

    public Modificator(float modValue = 0)
    {
        SetBaseValue(modValue, true);
    }

    public void AddValue(float modValue, bool isPersistent)
    {
        if (isPersistent == true)
        {
            SetBaseValue(BaseValue + modValue);
        }
        else
        {
            SetValue(TmpValue + modValue);
        }

    }

    public void SetValue(float modValue, bool isNotify = true)
    {
        TmpValue = modValue;

        if (isNotify == true)
        {
            NotifyLevelChanged();
        }
    }

    public void SetBaseValue(float modValue, bool isNotify = true)
    {
        BaseValue = modValue;

        if (isNotify == true)
        {
            NotifyLevelChanged();
        }
    }

    private void NotifyLevelChanged()
    {
        OnValueChanged(Value);
    }
}