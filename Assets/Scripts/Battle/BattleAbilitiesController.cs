using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleAbilitiesController
{
    [SerializeField]
    private AbilityBattleUIController abilityBattleUIController;
    public List<Ability> Abilities { get; set; }
    public List<Ability> AbilitiesLosuLosu { get; set; }

    public void InitializeAbilities(Abilities characterAbilities)
    {
        Abilities = new List<Ability>();
        AbilitiesLosuLosu = new List<Ability>();
        Abilities abilities = characterAbilities;
        List<int> knownAbilities = abilities.KnownAbilities;
        foreach (var abilityId in knownAbilities)
        {
            Ability ability = abilities.GetAbility(abilityId);
            ability.OnStateChanged += changedState => UpdateAbility(ability, changedState);
            Abilities.Add(ability);
            AbilitiesLosuLosu.Add(ability);
        }
        abilityBattleUIController.Init(Abilities);
    }

    public void UpdateAbility(Ability ability, AbilityState abilityState)
    {
        switch (abilityState)
        {
            case AbilityState.Ready:
                AbilitiesLosuLosu.Add(ability);
                break;
            case AbilityState.InUse:
                AbilitiesLosuLosu.Remove(ability);
                break;
            case AbilityState.Exhaust:
                ability.RemoveEffects();
                break;
            default:
                Debug.LogError("AbilityState not exist!");
                break;
        }
    }

    public void UpdateAbilities()
    {
        for (int i = Abilities.Count - 1; i >= 0; i--)
        {
            Abilities[i].UpdateTime();
        }
    }

    public Ability GetRandomAbility()
    {
        Ability randomAbility = null;

        if (AbilitiesLosuLosu.Count > 0)
        {
            randomAbility = AbilitiesLosuLosu[Random.Range(0, AbilitiesLosuLosu.Count)];
        }
        return randomAbility;
    }
}
