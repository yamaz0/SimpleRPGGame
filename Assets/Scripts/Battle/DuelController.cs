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
            float expToSub = Player.Instance.Character.Statistics.Exp.Value * 0.1f;
            Player.Instance.Character.Statistics.Exp.AddValue(-expToSub, true);
            //popup czy cos ze przegrana i ilosc odjetego expa
            PopUpManager.Instance.ShowEndBattlePopUp("LOSE", $"You are too weak. You lose {expToSub} experience.");

        }
        else if (op2.Character.Statistics.Hp.Value <= 0)
        {
            Player.Instance.Character.Statistics.Exp.AddValue(100, true);
            switch (Player.Instance.Character.Style)
            {
                case FightStyle.OneHand:
                    Player.Instance.Character.Statistics.OneHandedDamageBonus.AddValue(1, true);
                    break;
                case FightStyle.TwoHand:
                    Player.Instance.Character.Statistics.TwoHandedDamageBonus.AddValue(1, true);
                    break;
                case FightStyle.DualWield:
                    Player.Instance.Character.Statistics.DualWieldDamageBonus.AddValue(1, true);
                    break;
                default:
                    Debug.LogError("Style not exist!");
                    return;
            }
            PopUpManager.Instance.ShowEndBattlePopUp("WIN", $"You are very stronk. You get 100 experience.");
        }
    }


}
