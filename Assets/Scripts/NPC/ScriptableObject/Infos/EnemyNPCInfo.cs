using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyNPCInfo : NPCInfo
{
    [SerializeField]
    private Character character = new Character();

    public override NPCBase CreateNpc()
    {
        return new EnemyNPC(this);
    }
}