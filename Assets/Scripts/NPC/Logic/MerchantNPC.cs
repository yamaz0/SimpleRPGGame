using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPC : NPCBase
{
    public MerchantNPC(NPCInfo info) : base(info)
    {
    }

    public override void Use()
    {
        base.Use();
        //create shop GUI(info)
    }
}
