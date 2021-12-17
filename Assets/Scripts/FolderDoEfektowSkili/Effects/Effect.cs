using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    void Execute(Character character);
}

[System.Serializable]
public class Effect : IEffect
{
    [SerializeField]
    private string name;

    public string Name { get => name; set => name = value; }
    public virtual void Execute(Character character)
    {
        throw new System.NotImplementedException();
    }
}

[System.Serializable]
public class AddAttributeEffect : Effect
{
    [SerializeField]
    [ModDropdown("Attributes")]
    private string attributeName;
    [SerializeField]
    private float value;

    public string AttributeName { get => attributeName; set => attributeName = value; }

    public override void Execute(Character character)
    {
        Modificator modificator = character.Attributes.GetAttribute(attributeName);
        modificator.AddValue(value);
    }
}

[System.Serializable]
public class AddPlayerStatisticEffect : Effect
{
    [SerializeField]
    [ModDropdown("PlayerStatistics")]
    private string statisticName;
    [SerializeField]
    private float value;

    public string StatisticName { get => statisticName; set => statisticName = value; }

    public override void Execute(Character character)
    {
        Modificator modificator = character.PlayerStatistics.GetStatistic(statisticName);
        modificator.AddValue(value);
    }
}

[System.Serializable]
public class AddItemEffect : Effect
{
    [SerializeField]
    [ItemDropdown]
    private int itemId;
    [SerializeField]
    private bool isRemove = false;
    public bool IsRemove { get => isRemove; set => isRemove = value; }
    public int ItemId { get => itemId; set => itemId = value; }

    public override void Execute(Character character)
    {
        if (IsRemove == true)
            character.InventoryController.RemoveItem(ItemId);
        else
            character.InventoryController.AddItem(ItemId);
    }
}
