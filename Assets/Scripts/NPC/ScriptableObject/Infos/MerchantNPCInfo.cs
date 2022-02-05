using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPCInfo : NPCInfo
{
    public override NPCBase CreateNpc()
    {
        return new MerchantNPC(this);
    }
}
