using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ModificatorType]
[System.Serializable]
public class Abilities
{
    [SerializeField]
    private List<int> knownAbilities = new List<int>();
    [SerializeField]
    private List<int> chooseOneHandStyleAbilities = new List<int>();
    [SerializeField]
    private List<int> chooseTwoHandStyleAbilities = new List<int>();
    [SerializeField]
    private List<int> chooseDualWieldStyleAbilities = new List<int>();

    [Modificator]
    public List<int> KnownAbilities { get => knownAbilities; set => knownAbilities = value; }

    public event Action OnAbilitiesChanged = delegate { };

    public List<int> GetChoosedStyleAbilities(FightStyle style)
    {
        switch (style)
        {
            case FightStyle.OneHand:
                return chooseOneHandStyleAbilities;
            case FightStyle.TwoHand:
                return chooseTwoHandStyleAbilities;
            case FightStyle.DualWield:
                return chooseDualWieldStyleAbilities;
            default:
                Debug.LogError("WRONG FIGHT STYLE!!");
                return null;
        }
    }




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
