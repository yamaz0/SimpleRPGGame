using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerksManager : Singleton<PerksManager>
{
    public List<Perk> Perks { get; private set; }

    protected override void Initialize()
    {
        base.Initialize();
        List<PerkScriptableObject.PerkInfo> perksInfo = PerkScriptableObject.Instance.Perks;
        foreach (var perkInfo in perksInfo)
        {
            Perks.Add(new Perk(perkInfo));
        }
    }

    public void TryAddAllAvaiblePerks(Character character)
    {
        foreach (var perk in Perks)
        {
            bool hasCharacterPerk = character.Perks.KnownPerks.Contains(perk.PerkInfo.Id);

            if (hasCharacterPerk == false && CheckCondition(character.Attributes, perk.PerkInfo) == true)
                perk.ExecuteEffects(character);
        }
    }

    private bool CheckCondition(Attributes attributes, PerkScriptableObject.PerkInfo perkInfo)
    {
        return attributes.Strength.Value >= perkInfo.RequirmentsAttributes.Strength.Value
            && attributes.Dexterity.Value >= perkInfo.RequirmentsAttributes.Dexterity.Value
            && attributes.Endurance.Value >= perkInfo.RequirmentsAttributes.Endurance.Value;
    }

}
