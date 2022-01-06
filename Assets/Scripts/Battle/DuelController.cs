using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DuelController : MonoBehaviour
{
    public Opponent op1;
    public Opponent op2;

    public void Initialize(Character characterFirst, Character characterSecound)
    {
        op1.Initialize(characterFirst);
        op2.Initialize(characterSecound);
    }

    public void DoTurn()//TODO ogarnac lepszy sposob robienia tury
    {
        TryAttack(op1, op2);
        TryAttack(op2, op1);
        op1.Exhausted -= Time.deltaTime;
        op2.Exhausted -= Time.deltaTime;
        if(op1.hp <=0) Debug.Log("op1 przegral");
        if(op2.hp <=0) Debug.Log("op2 przegral");
    }

    private void TryAttack(Opponent attacker, Opponent attacked)
    {
        if (CheckOponentReady(attacker) == true)
        {
            attacker.Attack();
            attacker.Exhausted = attacker.Attackspeed * Random.Range(0.9f, 1.1f);
            attacked.hp -= attacker.Damage * Random.Range(0.9f, 1.1f);
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
        return op.CheckReady();
    }

}
