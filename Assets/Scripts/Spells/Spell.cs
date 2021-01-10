using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell
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
        SpellsScriptableObject.SpellType spellType;
        [SerializeField]
        SpellsScriptableObject.Element element;

    List<SpellEffectInfo> receiverSpellEffectsIds;
    List<SpellEffectInfo> targetSpellEffectsIds;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public SpellsScriptableObject.Element Element { get => Element1; set => Element1 = value; }
    public bool Unlock { get => unlock; set => unlock = value; }
    public float SpellPower { get => spellPower; set => spellPower = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
    public float ManaCost { get => manaCost; set => manaCost = value; }
    public SpellsScriptableObject.SpellType SpellType { get => spellType; set => spellType = value; }
    public SpellsScriptableObject.Element Element1 { get => element; set => element = value; }
    public List<SpellEffectInfo> ReceiverSpellEffectsInfos { get => receiverSpellEffectsIds; set => receiverSpellEffectsIds = value; }
    public List<SpellEffectInfo> TargetSpellEffectsInfos { get => targetSpellEffectsIds; set => targetSpellEffectsIds = value; }
    public Sprite Sprite { get; set; }

    public Spell(SpellsScriptableObject.SpellInfo spellInfo)
    {
        ReceiverSpellEffectsInfos = new List<SpellEffectInfo>();
        TargetSpellEffectsInfos = new List<SpellEffectInfo>();

        Name = spellInfo.Name;
        Id = spellInfo.Id;
        Element = spellInfo.Element;
        Unlock = spellInfo.Unlock;
        SpellPower = spellInfo.SpellPower;
        Cooldown = spellInfo.Cooldown;
        ManaCost = spellInfo.ManaCost;
        SpellType = spellInfo.SpellType;
        Element = spellInfo.Element;
        ReceiverSpellEffectsInfos.AddRange(spellInfo.ReceiverSpellEffectsInfos);
        TargetSpellEffectsInfos.AddRange(spellInfo.TargetSpellEffectsInfos);
        Sprite = spellInfo.Sprite;
    }

}
