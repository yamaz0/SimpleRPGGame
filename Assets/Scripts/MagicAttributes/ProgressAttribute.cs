    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressAttribute : Attribute
{
    [SerializeField]
    private float actualProgress;
    [SerializeField]
    private float requirementProgress = 100;

    public event Action<float> OnProgressChange = delegate { };
    // [SerializeField]
    // public Progress progres;
    public ProgressAttribute(AttributesScriptableObject.MagicAttributes id, int level = 0) : base(id, level)
    {
        // progres = new Progress();
    }

    public ProgressAttribute() : base()
    {
        // progres = new Progress();
    }

    public void CalculateRequirementProgress()
    {
        requirementProgress = 100 * (Level + 1);
        // SetProgress(0);
    }

    public void AddProgress(float value)
    {
        float calculateProgress = Mathf.Clamp(actualProgress + value, 0, float.MaxValue);

        while(calculateProgress >= requirementProgress)
        {
            calculateProgress -= requirementProgress;
            LevelUp();
            CalculateRequirementProgress();
        }
        SetProgress(calculateProgress);
    }

    public void SetProgress(float value)
    {
        actualProgress = value;
        float progressPercent = Mathf.RoundToInt(GetProgressPercent());
        OnProgressChange(progressPercent);
    }

    public bool CheckProgress()
    {
        if (actualProgress >= requirementProgress)
        {
            CalculateRequirementProgress();
            return true;
        }

        return false;
    }

    public float GetProgressPercent()
    {
        return actualProgress / requirementProgress * Constants.TO_PERCENT_MODIFIER;
    }

}
