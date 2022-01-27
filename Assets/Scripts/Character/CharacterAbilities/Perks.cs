using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ModificatorType]
[System.Serializable]
public class Perks
{
    [SerializeField]
    private List<int> knownPerks;

    [Modificator]
    public List<int> KnownPerks { get => knownPerks; set => knownPerks = value; }

    public event Action OnPerksChanged = delegate { };
    public Perk GetPerk(int id)
    {
        PerkScriptableObject.PerkInfo parkInfo = PerkScriptableObject.Instance.GetPerkInfoById(id);
        return new Perk(parkInfo);
    }
    public void AddPerk(int id)
    {
        KnownPerks.Add(id);
        OnPerksChanged();
    }
    public void RemovePerk(int id)
    {
        KnownPerks.Remove(id);
        OnPerksChanged();
    }
}