using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    [SerializeField]
    private AbilityInfo abilityInfo;
    public float TimeToEnd { get; set; }

    public AbilityInfo AbilityInfo { get => abilityInfo; set => abilityInfo = value; }

    public Ability(AbilityInfo info)
    {
        AbilityInfo = info;
        TimeToEnd = AbilityInfo.DurationTime;
    }

    public bool CheckTime(float time)
    {
        TimeToEnd -= time;
        return TimeToEnd <= 0;
    }

    public void ExecuteEffects(Character character)
    {
        foreach (var effect in AbilityInfo.Effects)
        {
            effect.Execute(character);
        }
    }

    public void RemoveEffects(Character character)
    {
        foreach (var effect in AbilityInfo.Effects)
        {
            effect.Execute(character);
        }
    }
}