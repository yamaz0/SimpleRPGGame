using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : Singleton<SpellsManager>
{
    [SerializeField]
    private List<Spell> spells;

    public List<Spell> Spells { get => spells; set => spells = value; }

    protected override void Initialize()
    {
        Spells.Clear();
        List<SpellsScriptableObject.SpellInfo> spellsInfo = SpellsScriptableObject.Instance.SpellsInfo;

        for (int i = 0; i < spellsInfo.Count; i++)
        {
            SpellsScriptableObject.SpellInfo spellInfo = spellsInfo[i];
            Spell createdSpell = new Spell(spellInfo);
            Spells.Add(createdSpell);
        }
    }

    public Spell GetSpellById(int id)
    {
        for (int i = 0; i < Spells.Count; i++)
        {
            if(Spells[i].Id == id)
            {
                return Spells[i];
            }
        }

        return null;
    }
}
