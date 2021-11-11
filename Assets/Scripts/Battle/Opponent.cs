using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    private List<SpellEffect> spellEffects = new List<SpellEffect>();
    public float hp = 100;
    public float mana = 100;
    private int exhaustedTurn = 0;

    public  Animator anim;
    public  OpponentSpriteController spritesController;

    public Character Character { get => character; set => character = value; }
    public List<Spell> Spells { get; set; }
    public List<Spell> AttackSpells { get; set; } = new List<Spell>();
    public List<Spell> DefendSpells { get; set; } = new List<Spell>();
    public List<Spell> BuffHealEtcSpells { get; set; } = new List<Spell>();
    public List<SpellEffect> SpellEffects { get => spellEffects; set => spellEffects = value; }

    public void Initialize(Character characterToCopy)
    {
        character = new Character();
        character.CopyCharacter(characterToCopy);
        Spells = new List<Spell>();
        List<int> knownSpellsId = Character.KnownSpellsId;
        for (int i = 0; i < knownSpellsId.Count; i++)
        {
            Spells.Add(SpellsManager.Instance.GetSpellById(knownSpellsId[i]));
        }

        foreach (Spell currentSpell in Spells)
        {
            switch (currentSpell.SpellType)
            {
                case SpellsScriptableObject.SpellType.ATTACK:
                    AttackSpells.Add(currentSpell);
                    break;
                case SpellsScriptableObject.SpellType.DEFEND:
                    DefendSpells.Add(currentSpell);
                    break;
                case SpellsScriptableObject.SpellType.BUFFHEALETC:
                    BuffHealEtcSpells.Add(currentSpell);
                    break;
                default:
                Debug.LogError("Nie prawidlowy typ czaru");
                break;
            }
        }
    }

    public bool CheckReadyToCast()
    {
        return exhaustedTurn <= 0;
    }

    public Spell GetRandomSpell()
    {
        int randomId = Random.Range(0,Character.KnownSpellsId.Count);
        return Spells[randomId];
    }

    public Spell GetRandomAttackSpell()
    {
        int randomId = Random.Range(0,AttackSpells.Count);
        return AttackSpells[randomId];
    }

    public Spell GetDefendSpell(Spell attackerSpell)
    {
        SpellsScriptableObject.Element attackerSpellElement = attackerSpell.Element;
        SpellsScriptableObject.Element counterDefendElement = GetCounterElement(attackerSpellElement);

        for (int i = 0; i < DefendSpells.Count; i++)
        {
            if(DefendSpells[i].Element == counterDefendElement || DefendSpells[i].Element == attackerSpellElement)
            {
                return DefendSpells[i];
            }
        }

        return null;
    }

    public SpellsScriptableObject.Element GetCounterElement(SpellsScriptableObject.Element element)
    {
        switch (element)
        {
            case SpellsScriptableObject.Element.FIRE:
                return SpellsScriptableObject.Element.WATER;
            case SpellsScriptableObject.Element.WATER:
                return SpellsScriptableObject.Element.EARTH;
            case SpellsScriptableObject.Element.EARTH:
                return SpellsScriptableObject.Element.AIR;
            case SpellsScriptableObject.Element.AIR:
                return SpellsScriptableObject.Element.FIRE;
            case SpellsScriptableObject.Element.WHITE:
                return SpellsScriptableObject.Element.BLACK;
            case SpellsScriptableObject.Element.BLACK:
                return SpellsScriptableObject.Element.WHITE;
            case SpellsScriptableObject.Element.ENERGY:
                return SpellsScriptableObject.Element.ENERGY;
            default:
            Debug.LogError("Blad nie ma takiego zywiolu!");
            break;
        }
            return element;
    }

    public void Attack(Spell spell)
    {
        spritesController.SetAttackSprite(spell.Sprite);
        anim.Play("Attack");
    }

    public void Defend(Spell spell)
    {
        spritesController.SetDefendSprite(spell.Sprite);
        anim.Play("Defend");
    }

    public void AddEffect(SpellEffect spellEffect)
    {
        spellEffect.Execute(this);

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
                currentSpellEffect.RemoveEffect(this);
                SpellEffects.RemoveAt(i);
                continue;
            }

            if(currentSpellEffect.IsRepeatable)//jesli efekt jest powtarzalny np dmg w czasie
            {
                currentSpellEffect.Execute(this);
            }
        }
    }
}