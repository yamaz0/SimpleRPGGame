using UnityEngine;

public class DuelRule : RuleBase
{
    private const float PERCENT_HP = 0.2f;

    public override void Check()
    {
        if (Op1.Character.Statistics.Hp.Value <= Op1.Character.Statistics.MaxHp.Value * PERCENT_HP)
        {
            OnLose();
        }
        else if (Op2.Character.Statistics.Hp.Value <= Op2.Character.Statistics.MaxHp.Value * PERCENT_HP)
        {
            OnWin();
        }
    }

    public override void OnLose()
    {
        float expToSub = Player.Instance.Character.Statistics.Exp.Value * 0.1f;
        Player.Instance.Character.Statistics.Exp.AddValue(-expToSub, true);
        //popup czy cos ze przegrana i ilosc odjetego expa
        PopUpManager.Instance.ShowEndBattlePopUp("LOSE", $"You are too weak. You lose {expToSub} experience.");
    }

    public override void OnWin()
    {
        Character playerCharacter = Player.Instance.Character;
        playerCharacter.Statistics.Exp.AddValue(100, true);

        switch (playerCharacter.Style)
        {
            case FightStyle.OneHand:
                playerCharacter.Statistics.OneHandedDamageBonus.AddValue(1, true);
                break;
            case FightStyle.TwoHand:
                playerCharacter.Statistics.TwoHandedDamageBonus.AddValue(1, true);
                break;
            case FightStyle.DualWield:
                playerCharacter.Statistics.DualWieldDamageBonus.AddValue(1, true);
                break;
            default:
                Debug.LogError("Style not exist!");
                return;
        }

        PopUpManager.Instance.ShowEndBattlePopUp("WIN", $"You are very stronk. You get 100 experience.");
    }
}
