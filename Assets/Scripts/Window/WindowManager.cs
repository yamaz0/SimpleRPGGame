using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    [SerializeField]
    private ShopController shopController;
    [SerializeField]
    private AbilitiesUIWindowController abilitiesUIWindowController;
    [SerializeField]
    private RandomCharacterWindowController randomCharacterWindowController;
    [SerializeField]
    private TournamentWindowController tournamentWindowController;
    [SerializeField]
    private AbilityWindowController abilityWindowController;
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private GameObject stats;

    public void ShowAbilities()
    {
        abilityWindowController.gameObject.SetActive(!abilityWindowController.gameObject.activeSelf);
    }

    public void ShowStats()
    {
        stats.gameObject.SetActive(!stats.gameObject.activeSelf);
    }

    public void ShowInventory()
    {
        inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    }

    public void ShowArena()
    {
        randomCharacterWindowController.Init();
        randomCharacterWindowController.gameObject.SetActive(true);
    }

    public void ShowTournament()
    {
        tournamentWindowController.Init();
        tournamentWindowController.gameObject.SetActive(true);
    }

    public void ShowAbilitiesWindow(TrainerNPCInfo info)
    {
        abilitiesUIWindowController.Init(info);
        abilitiesUIWindowController.gameObject.SetActive(true);
    }

    public void ShowShop(InventoryController npcInventoryController)
    {
        InventoryController playerInventoryController = Player.Instance.Character.InventoryController;

        shopController.Init(npcInventoryController, playerInventoryController);
        shopController.gameObject.SetActive(true);
    }
}
