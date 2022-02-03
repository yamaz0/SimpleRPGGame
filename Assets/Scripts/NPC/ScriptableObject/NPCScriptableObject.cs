using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCs", menuName = "ScriptableObjects/NPCs")]
public partial class NPCScriptableObject : ScriptableObject
{
    private static NPCScriptableObject instance;

    [SerializeField]
    private List<NPCInfo> npcs;

    public static NPCScriptableObject Instance { get { return instance; } }

    public List<NPCInfo> NPCs { get => npcs; set => npcs = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<NPCScriptableObject>("")[0];
    }

    public NPCScriptableObject()
    {
        instance = this;
    }

    public NPCInfo GetNPCInfoById(int id)
    {
        foreach (NPCInfo npcInfo in NPCs)
        {
            if (npcInfo.Id == id)
            {
                return npcInfo;
            }
        }

        return null;
    }

    public NPCInfo GetNPCInfoByNPC(string name)
    {
        foreach (NPCInfo npcInfo in NPCs)
        {
            if (npcInfo.Name == name)
            {
                return npcInfo;
            }
        }

        return null;
    }
}