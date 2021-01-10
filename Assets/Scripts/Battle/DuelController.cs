using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DuelController : MonoBehaviour
{
    public Opponent op1;
    public Opponent op2;

    bool TURNTEST;

    public void Initialize<S, T>(Character<S> characterFirst, Character<T> characterSecound) where T : Attribute where S : Attribute
    {
        op1.Initialize(characterFirst);
        op2.Initialize(characterSecound);
    }

    public void DoTurn()//TODO ogarnac lepszy sposob robienia tury
    {
        if(TURNTEST)
        TryAttack(op1, op2);
        else
        TryAttack(op2, op1);
        TURNTEST=!TURNTEST;
        op1.ExecuteEffects();
        op2.ExecuteEffects();
    }

    private void TryAttack(Opponent attacker, Opponent attacked)
    {
        if (CheckOponentReady(attacker) == true)
        {
            Spell attackerSpell = attacker.GetRandomAttackSpell();
            attacker.mana -= attackerSpell.ManaCost;
            attacker.Attack(attackerSpell);//jakis exhaust dodac
//if atakowany nie jest exhausted
            Spell attackedDefendSpell = attacked.GetDefendSpell(attackerSpell);
            if(attackedDefendSpell != null)
            {
                attacked.Defend(attackedDefendSpell);//jakis exhaust dodac

            }
            else
            {
                attacked.hp -= attackerSpell.SpellPower;
            }

            AddEffectToOponents(attacker, attacked, attackerSpell);
        }
    }

    private void AddEffectToOponents(Opponent receiverOp, Opponent targetOp, Spell spell)
    {
        AddEffectsToOponent(receiverOp, spell.ReceiverSpellEffectsInfos);
        AddEffectsToOponent(targetOp, spell.TargetSpellEffectsInfos);
    }

    private void AddEffectsToOponent(Opponent opponent, List<SpellEffectInfo> spellEffectsInfos)
    {
        for (int i = 0; i < spellEffectsInfos.Count; i++)
        {
            SpellEffect receiverSpellEffect = spellEffectsInfos[i].GetSpellEffect();
            opponent.AddEffect(receiverSpellEffect);
        }
    }

    public bool CheckOponentReady(Opponent op)
    {
        return op.CheckReadyToCast();
    }

}
