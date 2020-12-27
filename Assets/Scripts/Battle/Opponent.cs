using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent
{
    private Character<Attribute> character;
    private List<SpellEffect> spellEffects = new List<SpellEffect>();
    public float hp=100;
    public float mana=100;
    private int exhaustedTurn = 0;

    public Character<Attribute> Character { get => character; set => character = value; }
    public List<SpellEffect> SpellEffects { get => spellEffects; set => spellEffects = value; }

    public void Initialize(Character<Attribute> characterToCopy)
    {
        character = new NormalCharacter();
        character.CopyCharacter(characterToCopy);
    }

    public void Initialize(Character<ProgressAttribute> characterToCopy)
    {
        character = new NormalCharacter();
        character.CopyCharacter(characterToCopy);
    }

    public bool CheckReadyToCast()
    {
        return exhaustedTurn <= 0;
    }

    public Spell GetSpell()
    {
        int randomId = Random.Range(0,Character.KnownSpellsId.Count);
        int spellId = Character.KnownSpellsId[randomId];
        return SpellsManager.Instance.GetSpellById(spellId);
    }

    public void AddEffect(SpellEffect spellEffect)
    {
        spellEffect.Execute(Character);

        if(spellEffect.IsSingleUse == false)//jesli nie ma dzialac tylko raz, od razu
        {
            SpellEffects.Add(spellEffect);
        }
    }

    public void ExecuteEffects()
    {
        for (int i = SpellEffects.Count - 1; i >= 0 ; i--)
        {
            SpellEffect currentSpellEffect = SpellEffects[i];
            bool isActive = currentSpellEffect.CheckDurationEffect();

            if(isActive == false)
            {
                currentSpellEffect.RemoveEffect(Character);
                SpellEffects.RemoveAt(i);
                continue;
            }

            if(currentSpellEffect.IsRepeatable)//jesli efekt jest powtarzalny np dmg w czasie
            {
                currentSpellEffect.Execute(Character);
            }
        }
    }
}