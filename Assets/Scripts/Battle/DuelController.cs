using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DuelController : MonoBehaviour
{
    public Opponent op1;
    public Opponent op2;
    [SerializeField]
    private HealthsUIController hpui;

    public void Initialize(Character characterFirst, Character characterSecound)
    {
        op1.Initialize(characterFirst);
        op2.Initialize(characterSecound);
        hpui.Init(op1, op2);
    }

    public void DoTurn()//TODO ogarnac lepszy sposob robienia tury
    {
        TryAttack(op1, op2);
        TryAttack(op2, op1);
        op1.Exhausted -= Time.deltaTime;
        op2.Exhausted -= Time.deltaTime;
        if (op1.Character.Statistics.Hp.Value <= 0) Debug.Log("op1 przegral");
        if (op2.Character.Statistics.Hp.Value <= 0) Debug.Log("op2 przegral");
    }

    private void TryAttack(Opponent attacker, Opponent attacked)
    {
        if (CheckOponentReady(attacker) == true)
        {
            attacker.Attack();
            attacker.Exhausted = attacker.Character.Statistics.AttackSpeed.Value * Random.Range(0.9f, 1.1f);
            attacked.Character.Statistics.Hp.AddValue(-attacker.Character.Statistics.Damage.Value * Random.Range(0.9f, 1.1f),false);
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
