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
        PerkInfo = info;
    }

    public Perk(int perkId)
    {
        PerkScriptableObject.PerkInfo info = PerkScriptableObject.Instance.GetPerkInfoById(perkId);
        PerkInfo = info;
    }

    public PerkScriptableObject.PerkInfo PerkInfo { get => perkInfo; set => perkInfo = value; }

    public void ExecuteEffects(Character character)
    {
        WindowManager.Instance.ShowNotification($"New Perk: {PerkInfo.Name}", PerkInfo.Icon);

        PerkInfo.Efects.ForEach(x => x.Execute(character));
        character.Perks.AddPerk(PerkInfo.Id);
    }
}
