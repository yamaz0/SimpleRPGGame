[System.Serializable]
public class TwoOponentBattleEffect : Effect
{
    public  virtual void Execute(Opponent atacker, Opponent atacked){}
    public  virtual void Remove(Opponent atacker, Opponent atacked){}
}
