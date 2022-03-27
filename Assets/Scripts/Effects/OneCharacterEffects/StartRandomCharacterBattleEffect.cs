using System;

[System.Serializable]
public class StartRandomCharacterBattleEffect : OneCharacterEffect
{
    public override void Execute(Character character)
    {
        BattleManager.Instance.StartBattle(Player.Instance.Character, character);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
