using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopController : Window
{
    [SerializeField]
    private InventoryUI playerInventory;
    [SerializeField]
    private InventoryUI NPCInventory;

    public void Init(InventoryController NPCInventoryController, InventoryController playerInventoryController)
    {
        ((ShopInventory)playerInventory).Init(NPCInventoryController, playerInventoryController, true);
        ((ShopInventory)NPCInventory).Init(playerInventoryController, NPCInventoryController, false);
    }
}
