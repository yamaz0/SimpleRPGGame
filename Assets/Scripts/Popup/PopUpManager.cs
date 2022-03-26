using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    [SerializeField]
    private PopUpControllerUI popUpController;
    [SerializeField]
    private ShopController shopController;
    [SerializeField]
    private AbilitiesUIWindowController abilitiesUIWindowController;
    [SerializeField]
    private TooltipUI tooltip;

    public TooltipUI Tooltip { get => tooltip; set => tooltip = value; }

    public void ShowEndBattlePopUp(string title, string desc)
    {
        popUpController.ShowEndBattlePopUp(title, desc);
    }

    public void ShowAbilitiesWindow(TrainerNPCInfo info)
    {
        abilitiesUIWindowController.Init(info);
        abilitiesUIWindowController.gameObject.SetActive(true);
    }

    public void ShowShop(InventoryController npcInventoryController)
    {
        InventoryController playerInventoryController = Player.Instance.Character.InventoryController;

        shopController.ShowShop(npcInventoryController, playerInventoryController);
        shopController.gameObject.SetActive(true);
    }
}
