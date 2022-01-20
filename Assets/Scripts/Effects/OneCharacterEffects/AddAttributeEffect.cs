using System;
using UnityEngine;

[System.Serializable]
public class AddAttributeEffect : OneCharacterEffect
{
    [SerializeField]
    [ModDropdown(nameof(Attributes))]
    private string attributeName;
    [SerializeField]
    private bool isPersistent;
    [SerializeField]
    private float value;

    public string AttributeName { get => attributeName; set => attributeName = value; }
    public bool IsPersistent { get => isPersistent; set => isPersistent = value; }
    public float Value { get => value; set => this.value = value; }

    public override void Execute(Character character)
    {
        Modificator modificator = character.Attributes.GetAttribute(attributeName);
        modificator.AddValue(Value, IsPersistent);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
