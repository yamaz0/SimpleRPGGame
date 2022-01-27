using System;
using UnityEngine;

[System.Serializable]
public class AddPerkEffect : OneCharacterEffect
{
    [SerializeField]
    [PerkDropdown]
    private int perkId;

    public int PerkId { get => perkId; set => perkId = value; }

    public override void Execute(Character character)
    {
        Perk perk = new Perk(PerkId);
        perk.ExecuteEffects(character);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
