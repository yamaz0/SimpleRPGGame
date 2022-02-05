using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNPCInfo : NPCInfo
{
    public override NPCBase CreateNpc()
    {
        return new EnemyNPC(this);
    }
}