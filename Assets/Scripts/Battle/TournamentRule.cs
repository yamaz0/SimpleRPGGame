public class TournamentRule : RuleBase
{
    public override void Check()
    {
        if (Op1.Character.Statistics.Hp.Value <= 0)
        {
            OnLose();
        }
        else if (Op2.Character.Statistics.Hp.Value <= 0)
        {
            OnWin();
        }
    }

    public override void OnLose()
    {
        PopUpManager.Instance.ShowEndBattlePopUp("Lose", $"You are very weak.");
    }

    public override void OnWin()
    {
        Player.Instance.ProgressLevel++;
        PopUpManager.Instance.ShowEndBattlePopUp("WIN", $"You are very stronk.");
    }
}
