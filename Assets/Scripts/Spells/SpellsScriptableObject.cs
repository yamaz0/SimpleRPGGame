using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spells", menuName = "ScriptableObjects/Spells")]
public class SpellsScriptableObject: ScriptableObject
{
    private static SpellsScriptableObject instance;

    [SerializeField]
    private List<SpellInfo> spells;

    public static SpellsScriptableObject Instance { get { return instance; } }

    public List<SpellInfo> Spells { get => spells; set => spells = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<SpellsScriptableObject>("")[0];
    }

    public SpellsScriptableObject()
    {
        instance = this;
    }

    public SpellInfo GetSpellInfoById(int id)
    {
        foreach (SpellInfo nameInfo in Spells)
        {
            if (nameInfo.Id == id)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public SpellInfo GetSpellInfoByName(string name)
    {
        foreach (SpellInfo nameInfo in Spells)
        {
            if (nameInfo.Name == name)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public enum Element
    {
        FIRE,
        WATER,
        EARTH,
        AIR,
        WHITE,
        BLACK,
        ENERGY
    }

    public enum Specialization
    {
        BATTLE,
        PROTECT
    }

    [System.Serializable]
    public class SpellInfo
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int id;
        [SerializeField]
        bool unlock;
        [SerializeField]
        float dmg;
        [SerializeField]
        float cooldown;
        [SerializeField]
        float manaCost;
        [SerializeField]
        Specialization specialization;
        [SerializeField]
        Element element;
        [SerializeField]
        List<Attribute> requirements = AttributesFactory.GetNormalAttributes();

        public string Name { get => name; private set => name = value; }
        public int Id { get => id; private set => id = value; }
        public bool Unlock { get => unlock; private set => unlock = value; }
        public float Dmg { get => dmg; private set => dmg = value; }
        public float Cooldown { get => cooldown; private set => cooldown = value; }
        public float ManaCost { get => manaCost; private set => manaCost = value; }
        public Specialization Specialization { get => specialization; set => specialization = value; }
        public Element Element { get => element; private set => element = value; }
        public List<Attribute> Requirements { get => requirements; set => requirements = value; }
    }
}
