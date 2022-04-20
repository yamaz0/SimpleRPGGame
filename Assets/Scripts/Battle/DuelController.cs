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
    public RuleBase Rule;

    public void Initialize(Character characterFirst, Character characterSecound, RuleBase rule)
    {
        op1.Initialize(characterFirst, op2);
        op2.Initialize(characterSecound, op1);
        hpui.Init(op1, op2);
        Rule = rule;
        Rule.Init(op1, op2);
    }

    public void DoTurn()//TODO ogarnac lepszy sposob robienia tury
    {
        op1.DoTurn();
        op2.DoTurn();

        // do zmiany ale na razie tak do testu
        Rule.Check();
    }

}
