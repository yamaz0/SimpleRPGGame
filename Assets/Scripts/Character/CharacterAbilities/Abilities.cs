using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ModificatorType]
public class Abilities
{
    [SerializeField]
    private List<int> knownAbilities;

    [Modificator]
    public List<int> KnownAbilities { get => knownAbilities; set => knownAbilities = value; }

    public Ability GetAbility(int id)
    {
        AbilityInfo abilityInfo = AbilityScriptableObject.Instance.GetAbilityInfoById(id);
        return new Ability(abilityInfo);
    }
}
