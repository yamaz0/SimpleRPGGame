using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability: ITwoCharacterEffect
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

    public void Execute(Character character,Character character2)
    {
        foreach (var effect in AbilityInfo.TwoCharacterEffects)
        {
            effect.Execute(character,character2);
        }
        foreach (var effect in AbilityInfo.OneCharacterEffects)
        {
            effect.Execute(character);
        }
    }

    public void RemoveEffects(Character character,Character character2)
    {
        foreach (var effect in AbilityInfo.TwoCharacterEffects)
        {
            effect.Remove(character,character2);
        }
        foreach (var effect in AbilityInfo.OneCharacterEffects)
        {
            effect.Remove(character);
        }
    }
}