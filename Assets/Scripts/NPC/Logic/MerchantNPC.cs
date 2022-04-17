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

        MerchantNPCInfo npcInfo = ((MerchantNPCInfo)NpcInfo);
        foreach (var item in npcInfo.ItemsIds)
        {
            InventoryController.Inventory.ItemsId.Add(item.ID);
        }

        InventoryController.Inventory.Init();
        InventoryController.Inventory.AddGold(npcInfo.Gold);
    }


    public void Load()
    {

    }

    public override void Use()
    {
        InventoryController copy = new InventoryController();
        List<int> copyItemsId = copy.Inventory.ItemsId;

        Inventory inventory = InventoryController.Inventory;
        List<int> itemsIds = inventory.ItemsId;
        int playerProgressLevel = Player.Instance.ProgressLevel;

        for (int i = 0; i < itemsIds.Count; i++)
        {
            if (playerProgressLevel >= inventory.Items[i].UnlockLevel)
            {
                copyItemsId.Add(itemsIds[i]);
            }
        }

        copy.Inventory.Init();

        WindowManager.Instance.ShowShop(copy);
    }
}