using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
{
    private static T instance;

    [SerializeReference]
    private List<BaseInfo> objects = new List<BaseInfo>();

    public static T Instance { get => instance; set => instance = value; }
    public List<BaseInfo> Objects { get => objects; set => objects = value; }

    [RuntimeInitializeOnLoadMethod]
    protected static void Init()
    {
        instance = Resources.LoadAll<T>("")[0];
    }
}

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