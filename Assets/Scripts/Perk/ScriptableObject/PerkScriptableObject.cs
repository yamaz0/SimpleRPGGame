using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkObject", menuName = "ScriptableObjects/PerkObject")]
public class PerkScriptableObject : SingletonScriptableObject<PerkScriptableObject>
{
    public PerkInfo GetPerkInfoById(int id)
    {
        return (PerkInfo)Objects.GetElementById(id);
    }

    public PerkInfo GetPerkInfoByName(string name)
    {
        return (PerkInfo)Objects.GetElementByName(name);
    }

    public List<PerkInfo> GetPerksList()
    {
        List<PerkInfo> perks = new List<PerkInfo>(Objects.Count);

        foreach (PerkInfo perk in Objects)
        {
            perks.Add(perk);
        }

        return perks;
    }

    private void OnValidate()
    {
        foreach (PerkInfo perk in Objects)
        {
            if (perk.Icon == null)
                perk.Icon = Resources.LoadAll<Sprite>("")[0];
        }
    }

    [System.Serializable]
    public class PerkInfo : BaseInfo
    {
        [SerializeField]
        private Sprite icon;
        [SerializeField]
        private Attributes requirmentsAttributes;
        [SerializeReference]
        private List<OneCharacterEffect> efects = new List<OneCharacterEffect>();

        public Attributes RequirmentsAttributes { get => requirmentsAttributes; set => requirmentsAttributes = value; }
        public List<OneCharacterEffect> Efects { get => efects; set => efects = value; }
        public Sprite Icon { get => icon; set => icon = value; }
    }
}
#if UNITY_EDITOR

[UnityEditor.CustomEditor(typeof(PerkScriptableObject))]
public class PerksScriptableObjectEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        var script = (PerkScriptableObject)target;

        if (GUILayout.Button($"Add PerkInfo", GUILayout.Height(40)))
        {
            PerkScriptableObject.PerkInfo item = new PerkScriptableObject.PerkInfo();
            item.Id = script.Objects.Count;
            item.Icon = Resources.LoadAll<Sprite>("")[0];
            script.Objects.Add(item);
        }
        base.OnInspectorGUI();
    }
}

#endif