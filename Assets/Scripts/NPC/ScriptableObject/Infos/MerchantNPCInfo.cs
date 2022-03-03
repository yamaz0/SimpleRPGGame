using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPCInfo : NPCInfo
{
    [SerializeField]
    private List<int> itemsId = new List<int>();

    public List<int> ItemsId { get => itemsId; set => itemsId = value; }

    public override NPCBase CreateNpc()
    {
        return new MerchantNPC(this);
    }
}
