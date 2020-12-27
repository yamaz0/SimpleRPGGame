using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelController : MonoBehaviour
{
    public Opponent op1;
    public Opponent op2;

    public Player player;
    public Enemy enemy;
    bool TURNTEST;
    private void Start() {
        op1.Initialize(player.Character);
        op2.Initialize(enemy.Character);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.T))
        DoTurn();
    }
    public void DoTurn()
    {
        if(TURNTEST)
        TryAttack(op1, op2);
        else
        TryAttack(op2, op1);
        TURNTEST=!TURNTEST;
    }

    private void TryAttack(Opponent attacker, Opponent attacked)
    {
        if (CheckOponentReady(attacker) == true)
        {
            Spell attackerSpell = attacker.GetSpell();
            attacker.mana -=attackerSpell.ManaCost;
            attacked.hp -= attackerSpell.SpellPower;
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
