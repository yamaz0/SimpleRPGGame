using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCModel : MonoBehaviour
{
    [SerializeField]
    private NPCBase npc;

    public NPCBase Npc { get => npc; set => npc = value; }

#if UNITY_EDITOR

    [SerializeField]
    [IdDropdown(typeof(NPCScriptableObject))]
    // [NpcDropdown]
    private int npcId;

    private void OnValidate()
    {
        if (Npc != null && Npc.NpcInfo.Id != npcId)
        {
            Npc = NPCScriptableObject.Instance.GetNPCInfoById(npcId).CreateNpc();
            GetComponent<Animator>().runtimeAnimatorController=Npc.NpcInfo.AnimatorController;
        }
    }
#endif
}
