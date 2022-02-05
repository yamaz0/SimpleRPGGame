using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "NPCs", menuName = "ScriptableObjects/NPCs")]
[System.Serializable]
public class NPCScriptableObject : SingletonScriptableObject<NPCScriptableObject>
{
    private void OnEnable()
    {
        Objects.Add(new CommonNPCInfo());
        Objects.ForEach(x => Debug.Log(x.Name));
        Init();
    }

    public NPCInfo GetNPCInfoById(int id)
    {
        foreach (NPCInfo npcInfo in Objects)
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
        foreach (NPCInfo npcInfo in Objects)
        {
            if (npcInfo.Name == name)
            {
                return npcInfo;
            }
        }

        return null;
    }
}