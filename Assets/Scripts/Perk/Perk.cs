using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Perk
{
    [SerializeField]
    private PerkScriptableObject.PerkInfo perkInfo;

    public Perk(PerkScriptableObject.PerkInfo info)
    {
        perkInfo = info;
    }

    public bool CheckCondition(Attributes attributes)
    {
        return attributes.Strength.Value >= perkInfo.RequirmentsAttributes.Strength.Value
            && attributes.Dexterity.Value >= perkInfo.RequirmentsAttributes.Dexterity.Value
            && attributes.Endurance.Value >= perkInfo.RequirmentsAttributes.Endurance.Value;
    }

    public void ExecuteEffects(Character character)
    {
        perkInfo.Efects.ForEach(x => x.Execute(character));
    }
}
