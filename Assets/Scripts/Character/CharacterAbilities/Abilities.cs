using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ModificatorType]
[System.Serializable]
public class Abilities
{
    [SerializeField]
    private List<int> knownAbilities;

    [Modificator]
    public List<int> KnownAbilities { get => knownAbilities; set => knownAbilities = value; }

    public event Action OnAbilitiesChanged = delegate { };
    public Ability GetAbility(int id)
    {
        AbilityInfo abilityInfo = AbilityScriptableObject.Instance.GetAbilityInfoById(id);
        return new Ability(abilityInfo);
    }
    public void AddAbility(int id)
    {
        KnownAbilities.Add(id);
        OnAbilitiesChanged();
    }
    public void RemoveAbility(int id)
    {
        KnownAbilities.Remove(id);
        OnAbilitiesChanged();
    }
}
