using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    public float hp = 100;
    private int exhaustedTurn = 0;

    public  Animator anim;
    public  OpponentSpriteController spritesController;

    public Character Character { get => character; set => character = value; }

    public void Initialize(Character characterToCopy)
    {
        character = new Character();
        character.CopyCharacter(characterToCopy);
    }

    public bool CheckReadyToCast()
    {
        return exhaustedTurn <= 0;
    }

    public void Attack()
    {
        anim.Play("Attack");
    }

    public void Defend()
    {
        anim.Play("Defend");
    }

    public void AddEffect()
    {
        // spellEffect.Execute(this);

        // if(spellEffect.IsSingleUse == false)//jesli nie ma dzialac tylko raz, od razu
        // {
        //     SpellEffects.Add(spellEffect);
        // }
    }

    public void ExecuteEffects()
    {
        // for (int i = SpellEffects.Count - 1; i >= 0 ; i--)
        // {
        //     SpellEffect currentSpellEffect = SpellEffects[i];
        //     bool isActive = currentSpellEffect.CheckDurationEffect();

        //     if(isActive == false)
        //     {
        //         currentSpellEffect.RemoveEffect(this);
        //         SpellEffects.RemoveAt(i);
        //         continue;
        //     }

        //     if(currentSpellEffect.IsRepeatable)//jesli efekt jest powtarzalny np dmg w czasie
        //     {
        //         currentSpellEffect.Execute(this);
        //     }
        // }
    }
}