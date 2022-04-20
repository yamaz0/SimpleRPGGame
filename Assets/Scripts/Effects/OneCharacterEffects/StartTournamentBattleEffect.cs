using System;

[System.Serializable]
public class StartTournamentBattleEffect : OneCharacterEffect
{
    public override void Execute(Character character)
    {
        BattleManager.Instance.StartBattle(Player.Instance.Character, character, new TournamentRule());
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}