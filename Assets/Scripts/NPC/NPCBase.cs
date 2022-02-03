using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : IInteractable
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
