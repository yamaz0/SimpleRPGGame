using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DuelController : MonoBehaviour
{
    public Opponent op1;
    public Opponent op2;

    bool TURNTEST;

    public void Initialize(Character characterFirst, Character characterSecound)
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
//             Spell attackerSpell = attacker.GetRandomAttackSpell();
//             float dmg = attackerSpell.SpellPower;
//             attacker.mana -= attackerSpell.ManaCost;

//             attacker.Attack(attackerSpell);//jakis exhaust dodac
// //if atakowany nie jest exhausted


//             if(attackedDefendSpell != null)
//             {
//                 //TODO jakies obliczenia jakie obrazenia zadaje czy cos
//                 dmg = dmg / 3; //przykladowo
//                 attacked.Defend(attackedDefendSpell);//jakis exhaust dodac
//             }

//             attacked.hp -= dmg;

//             AddEffectToOponents(attacker, attacked, attackerSpell);
        }
    }

    private void AddEffectToOponents(Opponent receiverOp, Opponent targetOp)
    {
        AddEffectsToOponent(receiverOp);
        AddEffectsToOponent(targetOp);
    }

    private void AddEffectsToOponent(Opponent opponent)
    {

    }

    public bool CheckOponentReady(Opponent op)
    {
        return op.CheckReadyToCast();
    }

}
