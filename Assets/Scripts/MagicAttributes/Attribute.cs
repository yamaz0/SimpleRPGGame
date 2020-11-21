using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int level;
    [SerializeField]
    private float actualProgress;
    [SerializeField]
    private float requirementProgress;

    public int Level { get => level; private set => level = value; }
    public event Action<float> OnProgressChange = delegate { };

    private void CalculateRequirementProgress()
    {
        requirementProgress = 100 * (Level + 1);
    }

    private void LevelUp()
    {
        Level++;
        actualProgress = 0;
        CalculateRequirementProgress();
    }

    private void CheckProgress()
    {
        if (actualProgress >= requirementProgress)
        {
            LevelUp();
        }
    }

    public void AddProgress(float value)
    {
        float calculateProgress = Mathf.Clamp(actualProgress + value, 0, requirementProgress);
        SetProgress(calculateProgress);
    }

    public void SetProgress(float value)
    {
        actualProgress = value;
        CheckProgress();
        OnProgressChange(actualProgress);
    }

    public float GetProgressPercent()
    {
        return actualProgress / requirementProgress;
    }
}
