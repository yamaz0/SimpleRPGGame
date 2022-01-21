using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityState { Ready, InUse, Exhaust }

public class Ability : ITwoCharacterEffect
{
    [SerializeField]
    private AbilityInfo abilityInfo;
    public TurnTimer DurationTimer { get; set; }
    public TurnTimer ExhaustTimer { get; set; }

    public AbilityInfo AbilityInfo { get => abilityInfo; set => abilityInfo = value; }
    public AbilityState State { get; set; }

    public event System.Action<AbilityState> OnStateChanged = delegate { };

    public Ability(AbilityInfo info)
    {
        AbilityInfo = info;
        DurationTimer = new TurnTimer(AbilityInfo.DurationTime);
        ExhaustTimer = new TurnTimer(AbilityInfo.ExahustTime);
    }

    public void UpdateTime()
    {
        switch (State)
        {
            case AbilityState.Ready:
                return;
            case AbilityState.InUse:
                TryChangeState(DurationTimer, AbilityState.Exhaust);
                break;
            case AbilityState.Exhaust:
                TryChangeState(ExhaustTimer, AbilityState.Ready);
                break;
            default:
                Debug.LogError("Wrong AbilityState state!");
                break;
        }
    }

    private void TryChangeState(TurnTimer timer, AbilityState state)
    {
        if (timer.CheckTime() == true)
        {
            timer.Reset();
            ChangeState(state);
        }
    }

    private void ChangeState(AbilityState abilityState)
    {
        State = abilityState;
        OnStateChanged(State);
    }

    public void Execute(Opponent attacker, Opponent attacked)
    {
        ChangeState(AbilityState.InUse);

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