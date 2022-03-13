using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MerchantNPC : NPCBase
{
    public InventoryController InventoryController { get; set; }
    public MerchantNPC(NPCInfo info) : base(info)
    {
        InventoryController = new InventoryController();
        Inventory inventoryInfo = ((MerchantNPCInfo)NpcInfo).InventoryController.Inventory;

        foreach (var itemId in inventoryInfo.ItemsId)
        {
            InventoryController.Inventory.ItemsId.Add(itemId);
        }

        InventoryController.Inventory.Init();
        InventoryController.Inventory.AddGold(inventoryInfo.Gold);
    }


    public void Load()
    {

    }

    public override void Use()
    {
        PopUpManager.Instance.ShowShop(InventoryController);
    }
}
