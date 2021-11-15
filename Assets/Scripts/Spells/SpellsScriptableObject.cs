﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spells", menuName = "ScriptableObjects/Spells")]
public class SpellsScriptableObject: ScriptableObject
{
    private static SpellsScriptableObject instance;

    [SerializeField]
    private List<SpellInfo> spells;

    public static SpellsScriptableObject Instance { get { return instance; } }

    public List<SpellInfo> SpellsInfo { get => spells; set => spells = value; }

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
        foreach (SpellInfo spellInfo in SpellsInfo)
        {
            if (spellInfo.Id == id)
            {
                return spellInfo;
            }
        }

        return null;
    }

    public SpellInfo GetSpellInfoByName(string name)
    {
        foreach (SpellInfo spellInfo in SpellsInfo)
        {
            if (spellInfo.Name == name)
            {
                return spellInfo;
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

    public enum SpellType
    {
        ATTACK,
        DEFEND,
        BUFFHEALETC//to change
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
        float spellPower;
        [SerializeField]
        float cooldown;
        [SerializeField]
        float manaCost;
        [SerializeField]
        SpellType spellType;
        [SerializeField]
        Element element;
        [SerializeField]
        Attributes requirements = new Attributes();
        [SerializeField]
        List<SpellEffectInfo> receiverEffects;
        [SerializeField]
        List<SpellEffectInfo> targetEffects;
        [SerializeField]
        Sprite sprite;

        public string Name { get => name; private set => name = value; }
        public int Id { get => id; private set => id = value; }
        public bool Unlock { get => unlock; private set => unlock = value; }
        public float SpellPower { get => spellPower; private set => spellPower = value; }
        public float Cooldown { get => cooldown; private set => cooldown = value; }
        public float ManaCost { get => manaCost; private set => manaCost = value; }
        public SpellType SpellType { get => spellType; set => spellType = value; }
        public Element Element { get => element; private set => element = value; }
        public Attributes Requirements { get => requirements; set => requirements = value; }
        public List<SpellEffectInfo> ReceiverSpellEffectsInfos { get => receiverEffects; set => receiverEffects = value; }
        public List<SpellEffectInfo> TargetSpellEffectsInfos { get => targetEffects; set => targetEffects = value; }
        public Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
