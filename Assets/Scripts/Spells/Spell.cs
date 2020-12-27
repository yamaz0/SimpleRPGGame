using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell
{
    string name;
    int id;
    SpellsScriptableObject.Element element;
    bool unlock;
    float spellPower;
    float cooldown;
    float manaCost;

    List<SpellEffectInfo> receiverSpellEffectsIds;
    List<SpellEffectInfo> targetSpellEffectsIds;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public SpellsScriptableObject.Element Element { get => element; set => element = value; }
    public bool Unlock { get => unlock; set => unlock = value; }
    public float SpellPower { get => spellPower; set => spellPower = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
    public float ManaCost { get => manaCost; set => manaCost = value; }
    public List<SpellEffectInfo> ReceiverSpellEffectsInfos { get => receiverSpellEffectsIds; set => receiverSpellEffectsIds = value; }
    public List<SpellEffectInfo> TargetSpellEffectsInfos { get => targetSpellEffectsIds; set => targetSpellEffectsIds = value; }

    public Spell(SpellsScriptableObject.SpellInfo spellInfo)
    {
        Name = spellInfo.Name;
        Id = spellInfo.Id;
        Element = spellInfo.Element;
        Unlock = spellInfo.Unlock;
        SpellPower = spellInfo.SpellPower;
        Cooldown = spellInfo.Cooldown;
        ManaCost = spellInfo.ManaCost;
        ReceiverSpellEffectsInfos = new List<SpellEffectInfo>();
        TargetSpellEffectsInfos = new List<SpellEffectInfo>();
        ReceiverSpellEffectsInfos.AddRange(spellInfo.ReceiverSpellEffectsInfos);
        TargetSpellEffectsInfos.AddRange(spellInfo.TargetSpellEffectsInfos);
    }

}
