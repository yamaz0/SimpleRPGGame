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
        op1.Initialize(characterFirst, op2);
        op2.Initialize(characterSecound, op1);
        hpui.Init(op1, op2);
    }

    public void DoTurn()//TODO ogarnac lepszy sposob robienia tury
    {
        op1.DoTurn();
        op2.DoTurn();

        // do zmiany ale na razie tak do testu
        if (op1.Character.Statistics.Hp.Value <= 0)
        {
            BattleManager.Instance.walka = false;
            Debug.Log("gracz przegral");
            Destroy(gameObject);
        }
        else if (op2.Character.Statistics.Hp.Value <= 0)
        {
            Debug.Log("gracz wygral");
            BattleManager.Instance.walka = false;
            Destroy(gameObject);
        }
    }


}
