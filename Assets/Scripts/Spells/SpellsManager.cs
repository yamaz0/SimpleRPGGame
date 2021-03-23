using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : Singleton<SpellsManager>
{
    // [SerializeField]
    // private List<Spell> spells;

    // public List<Spell> Spells { get => spells; set => spells = value; }

    protected override void Initialize()
    {
        // Spells.Clear();
        // List<SpellsScriptableObject.SpellInfo> spellsInfo = SpellsScriptableObject.Instance.SpellsInfo;

        // for (int i = 0; i < spellsInfo.Count; i++)
        // {
        //     SpellsScriptableObject.SpellInfo spellInfo = spellsInfo[i];
        //     Spell createdSpell = new Spell(spellInfo);
        //     Spells.Add(createdSpell);
        // }
    }

    public Spell GetSpellById(int id)
    {
        List<SpellsScriptableObject.SpellInfo> spellsInfo = SpellsScriptableObject.Instance.SpellsInfo;

        for (int i = 0; i < spellsInfo.Count; i++)
        {
            if(spellsInfo[i].Id == id)
            {
                return new Spell(spellsInfo[i]);
            }
        }

        return null;
    }
}
