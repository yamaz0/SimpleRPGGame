using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    string name;
    SpellsScriptableObject.Element element;
    bool unlock;
    float dmg;
    float cooldown;
    float manaCost;

    public Spell(SpellsScriptableObject.SpellInfo spellInfo)
    {
        name = spellInfo.Name;
        element =spellInfo.Element;
        unlock =spellInfo.Unlock;
        dmg =spellInfo.Dmg;
        cooldown =spellInfo.Cooldown;
        manaCost =spellInfo.ManaCost;
    }
}
