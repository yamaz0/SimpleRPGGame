using System;
using UnityEngine;

[System.Serializable]
public class AddCharacterStatisticEffect : OneCharacterEffect
{
    [SerializeField]
    [ModDropdown(nameof(CharacterStatistics))]
    private string statisticName;
    [SerializeField]
    private float value;

    public string StatisticName { get => statisticName; set => statisticName = value; }

    public override void Execute(Character character)
    {
        Modificator modificator = character.Statistics.GetStatistic(statisticName);
        modificator.AddValue(value);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
