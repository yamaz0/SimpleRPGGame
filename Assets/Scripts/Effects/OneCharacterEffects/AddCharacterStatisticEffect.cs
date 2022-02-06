using System;
using UnityEngine;

[System.Serializable]
public class AddCharacterStatisticEffect : OneCharacterEffect
{
    [SerializeField]
    [NameDropdown(nameof(CharacterStatistics))]
    private string statisticName;
    [SerializeField]
    private bool isPersistent;

    [SerializeField]
    private float value;

    public string StatisticName { get => statisticName; set => statisticName = value; }
    public bool IsPersistent { get => isPersistent; set => isPersistent = value; }
    public float Value { get => value; set => this.value = value; }

    public override void Execute(Character character)
    {
        Modificator modificator = character.Statistics.GetStatistic(statisticName);
        modificator.AddValue(Value, IsPersistent);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
