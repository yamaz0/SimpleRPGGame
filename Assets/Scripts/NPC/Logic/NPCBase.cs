using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCBase
{
    [SerializeField]
    private NPCInfo npcInfo;

    public NPCInfo NpcInfo { get => npcInfo; set => npcInfo = value; }

    public NPCBase(NPCInfo info)
    {
        NpcInfo = info;
    }

    public virtual void Use()
    {
        Debug.LogError("NPCBASE ERROR SERIALIZE USE METHOD");
    }
}
