using System;
using UnityEngine;

[System.Serializable]
public class StartBattleEffect : OneCharacterEffect
{
    [SerializeReference]
    private Enemy enemyCharacter;

    public Enemy EnemyCharacter { get => enemyCharacter; set => enemyCharacter = value; }

    public override void Execute(Character character)
    {
        BattleManager.Instance.StartBattle(character, EnemyCharacter.Character, new DuelRule());
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
