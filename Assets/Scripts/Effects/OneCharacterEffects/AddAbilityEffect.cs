using System;
using UnityEngine;

[System.Serializable]
public class AddAbilityEffect : OneCharacterEffect
{
    [SerializeField]
    [IdDropdown(typeof(AbilityScriptableObject))]
    private int abilityId;
    [SerializeField]
    private bool isRemove = false;
    public bool IsRemove { get => isRemove; set => isRemove = value; }
    public int AbilityId { get => abilityId; set => abilityId = value; }

    public override void Execute(Character character)
    {
        if (IsRemove == false)
            character.Abilities.AddAbility(AbilityId);
        else
            character.Abilities.RemoveAbility(AbilityId);
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        return $"Added ability: {AbilityScriptableObject.Instance.GetAbilityInfoById(AbilityId).Name}.";
    }
}
