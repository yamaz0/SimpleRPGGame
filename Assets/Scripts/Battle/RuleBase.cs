public abstract class RuleBase
{
    public Opponent Op1 { get; private set; }
    public Opponent Op2 { get; private set; }

    public void Init(Opponent firstOpponent, Opponent secoundOpponent)
    {
        Op1 = firstOpponent;
        Op2 = secoundOpponent;
    }

    public abstract void Check();
    public abstract void OnWin();
    public abstract void OnLose();
}
