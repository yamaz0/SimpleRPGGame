using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    [SerializeField]
    private PopUpControllerUI popUpController;

    [SerializeField]
    private ItemTooltipUI itemTooltip;
    [SerializeField]
    private PerkTooltipUI perkTooltip;

    public ItemTooltipUI ItemTooltip { get => itemTooltip; set => itemTooltip = value; }
    public PerkTooltipUI PerkTooltip { get => perkTooltip; set => perkTooltip = value; }

    public void ShowItemTooltip(Item ItemCache, Vector3 pos)
    {
        ItemTooltip.gameObject.SetActive(true);
        ItemTooltip.Init(ItemCache, pos);
    }

    public void ShowPerkTooltip(Perk perk, Vector3 pos)
    {
        PerkTooltip.gameObject.SetActive(true);
        PerkTooltip.Init(perk, pos);
    }

    public void ShowEndBattlePopUp(string title, string desc)
    {
        popUpController.ShowEndBattlePopUp(title, desc);
    }

}
