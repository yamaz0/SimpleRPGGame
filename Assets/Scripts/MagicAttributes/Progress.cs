using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    // [SerializeField]
    // private float actualProgress;
    // [SerializeField]
    // private float requirementProgress = 100;

    // public event Action<float> OnProgressChange = delegate { };

    // public void CalculateRequirementProgress(int Level)
    // {
    //     requirementProgress = 100 * (Level + 1);
    //     SetProgress(0);
    // }

    // public void AddProgress(float value)
    // {
    //     float calculateProgress = Mathf.Clamp(actualProgress + value, 0, requirementProgress);
    //     SetProgress(calculateProgress);
    // }

    // public void SetProgress(float value)
    // {
    //     actualProgress = value;
    //     float progressPercent = GetProgressPercent();
    //     OnProgressChange(progressPercent);
    // }

    // public bool CheckProgress(int level)
    // {
    //     if (actualProgress >= requirementProgress)
    //     {
    //         CalculateRequirementProgress(level);
    //         return true;
    //     }

    //     return false;
    // }

    // public float GetProgressPercent()
    // {
    //     return actualProgress / requirementProgress * Constants.TO_PERCENT_MODIFIER;
    // }
}
