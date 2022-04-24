using System;

[System.Serializable]
public class ShowTournamentWindowEffect : OneCharacterEffect
{
    public override void Execute(Character character)
    {
        WindowManager.Instance.ShowTournament();
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
