using System;
using UnityEngine;
using System.Text;

[System.Serializable]
public class PerkTooltipUI : TooltipUI
{
    public void Init(Perk perk, Vector3 position)
    {
        transform.position = position;
        ItemNameText.SetText(perk.PerkInfo.Name);
        StringBuilder perkEffectDesc = new StringBuilder($"Effects:{Environment.NewLine}");

        for (int i = 0; i < perk.PerkInfo.Efects.Count; i++)
        {
            perkEffectDesc.Append(perk.PerkInfo.Efects[i].GetDescription());
            perkEffectDesc.Append(Environment.NewLine);
        }

        DescText.SetText(perkEffectDesc.ToString());
    }
}
