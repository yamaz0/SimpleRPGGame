using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ITwoCharacterEffect
{
    [SerializeField]
    private AbilityInfo abilityInfo;
    public int DurationTime { get; set; }
    public int ExhaustTime { get; set; }

    public AbilityInfo AbilityInfo { get => abilityInfo; set => abilityInfo = value; }

    public Ability(AbilityInfo info)
    {
        AbilityInfo = info;
        DurationTime = AbilityInfo.DurationTime;
    }

    public bool CheckDurationTime()
    {
        DurationTime--;
        return DurationTime <= 0;
    }

    public bool CheckExhaustTime()
    {
        ExhaustTime--;
        return ExhaustTime <= 0;
    }

    public void Execute(Opponent attacker, Opponent attacked)
    {
        DurationTime = AbilityInfo.DurationTime;

        foreach (var effect in AbilityInfo.TwoOponentBattleEffects)
        {
            effect.Execute(attacker, attacked);
        }
        foreach (var effect in AbilityInfo.OneCharacterEffects)
        {
            effect.Execute(attacker.Character);
        }
    }

    public void RemoveEffects(Opponent attacker, Opponent attacked)
    {
        ExhaustTime = AbilityInfo.ExahustTime;

        foreach (var effect in AbilityInfo.TwoOponentBattleEffects)
        {
            effect.Remove(attacker, attacked);
        }
        foreach (var effect in AbilityInfo.OneCharacterEffects)
        {
            effect.Remove(attacker.Character);
        }
    }
}