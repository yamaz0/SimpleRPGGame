using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCModel : InteractObject
{
    [SerializeField]
    private NPCBase npc;

    public NPCBase Npc { get => npc; set => npc = value; }

    private void Start()
    {
        Npc = NPCScriptableObject.Instance.GetNPCInfoById(npcId).CreateNpc();
    }

    public override void Use()
    {
        Npc.Use();
    }

#if UNITY_EDITOR
    [SerializeField]
    [IdDropdown(typeof(NPCScriptableObject))]
    private int npcId;

    private void OnValidate()
    {
        NPCInfo nPCInfo = NPCScriptableObject.Instance.GetNPCInfoById(npcId);
        GetComponent<Animator>().runtimeAnimatorController = nPCInfo.AnimatorController;
        GetComponent<SpriteRenderer>().sprite = nPCInfo.Icon;
        gameObject.name = nPCInfo.Name;
    }
#endif
}
