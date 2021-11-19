using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ItemsSO", menuName = "ScriptableObjects/ItemsSO")]
public class ItemsSO: ScriptableObject
{
    private static ItemsSO instance;
    public static ItemsSO Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.LoadAll<ItemsSO>("")[0];
            }
            return instance;
        }
    }
}
