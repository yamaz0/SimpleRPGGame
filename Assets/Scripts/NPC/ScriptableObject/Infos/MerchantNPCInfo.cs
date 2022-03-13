using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MerchantNPCInfo : NPCInfo
{
    [SerializeField]
    private InventoryController inventoryController = new InventoryController();

    public InventoryController InventoryController { get => inventoryController; set => inventoryController = value; }

    public override NPCBase CreateNpc()
    {
        return new MerchantNPC(this);
    }
}
