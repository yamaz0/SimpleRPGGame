using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopController : MonoBehaviour
{
    [SerializeField]
    private InventoryUI playerInventory;
    [SerializeField]
    private InventoryUI NPCInventory;

    public void ShowShop(InventoryController NPCInventoryController, InventoryController playerInventoryController)
    {
        ((ShopInventory)playerInventory).Init(NPCInventoryController, playerInventoryController, true);
        ((ShopInventory)NPCInventory).Init(playerInventoryController, NPCInventoryController, false);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
