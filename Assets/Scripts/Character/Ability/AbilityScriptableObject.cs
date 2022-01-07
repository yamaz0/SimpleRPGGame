using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityScriptableObject", menuName = "ScriptableObjects/AbilityScriptableObject")]
public class AbilityScriptableObject : ScriptableObject
{
    private static AbilityScriptableObject instance;

    [SerializeField]
    private List<AbilityInfo> abilities;

    public static AbilityScriptableObject Instance { get { return instance; } }

    public List<AbilityInfo> Abilities { get => abilities; set => abilities = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<AbilityScriptableObject>("")[0];
    }

    public AbilityScriptableObject()
    {
        instance = this;
    }

    public AbilityInfo GetAbilityInfoById(int id)
    {
        foreach (AbilityInfo abilityInfo in Abilities)
        {
            if (abilityInfo.Id == id)
            {
                return abilityInfo;
            }
        }

        return null;
    }

    public AbilityInfo GetAbilityInfoByName(string name)
    {
        foreach (AbilityInfo abilityInfo in Abilities)
        {
            if (abilityInfo.Name == name)
            {
                return abilityInfo;
            }
        }

        return null;
    }
}
[System.Serializable]
public class AbilityInfo
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private List<Effect> effects;
    [SerializeField]
    private float durationTime;
    [SerializeField]
    private bool isSingleUse = false;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public List<Effect> Effects { get => effects; set => effects = value; }
    public float DurationTime { get => durationTime; set => durationTime = value; }
    public bool IsSingleUse { get => isSingleUse; set => isSingleUse = value; }
    public Sprite Icon { get => icon; set => icon = value; }
}

