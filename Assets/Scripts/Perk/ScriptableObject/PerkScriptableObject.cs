using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkObject", menuName = "ScriptableObjects/PerkObject")]
public class PerkScriptableObject : ScriptableObject
{
    private static PerkScriptableObject instance;

    [SerializeField]
    private List<PerkInfo> perks;

    public static PerkScriptableObject Instance { get { return instance; } }

    public List<PerkInfo> Perks { get => perks; set => perks = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<PerkScriptableObject>("")[0];
    }

    public PerkScriptableObject()
    {
        instance = this;
    }

    public PerkInfo GetPerkInfoById(int id)
    {
        foreach (PerkInfo perkInfo in Perks)
        {
            if (perkInfo.Id == id)
            {
                return perkInfo;
            }
        }

        return null;
    }

    public PerkInfo GetPerkInfoByName(string name)
    {
        foreach (PerkInfo perkInfo in Perks)
        {
            if (perkInfo.Name == name)
            {
                return perkInfo;
            }
        }

        return null;
    }
    private void OnValidate() {
        Perks.ForEach(x => {if(x.Icon == null) x.Icon = Resources.LoadAll<Sprite>("")[0];});
    }

    [System.Serializable]
    public class PerkInfo
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int id;
        [SerializeField]
        private Sprite icon;
        [SerializeField]
        private Attributes requirmentsAttributes;
        [SerializeReference]
        private List<OneCharacterEffect> efects;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public Attributes RequirmentsAttributes { get => requirmentsAttributes; set => requirmentsAttributes = value; }
        public List<OneCharacterEffect> Efects { get => efects; set => efects = value; }
        public Sprite Icon { get => icon; set => icon = value; }
    }
}