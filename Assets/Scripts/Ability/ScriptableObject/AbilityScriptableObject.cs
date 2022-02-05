using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityScriptableObject", menuName = "ScriptableObjects/AbilityScriptableObject")]
public class AbilityScriptableObject : SingletonScriptableObject<AbilityScriptableObject>
{

    public AbilityScriptableObject()
    {
        Instance = this;
    }

    public AbilityInfo GetAbilityInfoById(int id)
    {
        return (AbilityInfo)Objects.GetElementById(id);
    }

    public AbilityInfo GetAbilityInfoByName(string name)
    {
        return (AbilityInfo)Objects.GetElementByName(name);
    }

    public List<AbilityInfo> GetAbilitiesList()
    {
        List<AbilityInfo> abilities = new List<AbilityInfo>(Objects.Count);

        foreach (AbilityInfo ability in Objects)
        {
            abilities.Add(ability);
        }

        return abilities;
    }

    private void OnValidate()
    {
        foreach (AbilityInfo ability in Objects)
        {
            if (ability.Icon == null)
                ability.Icon = Resources.LoadAll<Sprite>("")[0];
        }
    }
}
[System.Serializable]
public class AbilityInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeReference]
    private List<TwoOponentBattleEffect> twoOponentBattleEffects;
    [SerializeReference]
    private List<OneCharacterEffect> oneCharacterEffects;
    [SerializeField]
    private int durationTime;
    [SerializeField]
    private int exahustTime;
    [SerializeField]
    private FightStyle style;

    public List<OneCharacterEffect> OneCharacterEffects { get => oneCharacterEffects; set => oneCharacterEffects = value; }
    public List<TwoOponentBattleEffect> TwoOponentBattleEffects { get => twoOponentBattleEffects; set => twoOponentBattleEffects = value; }
    public int DurationTime { get => durationTime; set => durationTime = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public int ExahustTime { get => exahustTime; set => exahustTime = value; }
    public FightStyle Style { get => style; set => style = value; }
}


[UnityEditor.CustomEditor(typeof(AbilityScriptableObject))]
public class AbilityScriptableObjectEditor : UnityEditor.Editor
{    public override void OnInspectorGUI()
    {
        var script = (AbilityScriptableObject)target;

        if (GUILayout.Button($"Add AbilityInfo", GUILayout.Height(40)))
        {
            script.Objects.Add(new AbilityInfo());
        }
        base.OnInspectorGUI();
    }
}
