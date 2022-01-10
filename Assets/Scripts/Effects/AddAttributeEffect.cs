using System;
using UnityEngine;

[System.Serializable]
public class AddAttributeEffect : OneCharacterEffect
{
    [SerializeField]
    [ModDropdown(nameof(Attributes))]
    private string attributeName;
    [SerializeField]
    private float value;

    public string AttributeName { get => attributeName; set => attributeName = value; }

    public override void Execute(Character character)
    {
        Modificator modificator = character.Attributes.GetAttribute(attributeName);
        modificator.AddValue(value);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
