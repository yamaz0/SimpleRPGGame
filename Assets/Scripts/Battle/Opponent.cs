using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    private float exhaustedTime = 1;

    public Animator anim;
    public OpponentSpriteController spritesController;

    public Character Character { get => character; set => character = value; }
    public float ExhaustedTime { get => exhaustedTime; set => exhaustedTime = value; }
    public List<Ability> Abilities { get; set; }
    public List<Ability> AbilitiesInUse { get; set; }
    public List<Ability> AbilitiesExhausted { get; set; }
    public Opponent CacheOpponent { get; set; }
    public event System.Action OnCharacterAttacked = delegate { };

    public enum FightStyle { OneHandWeapon, TwoHandWeapon, DualWield }

    public void Initialize(Character character, Opponent opponent)
    {
        Character = character;
        CacheOpponent = opponent;
        spritesController.SetSprites(Character);
        Character.UpdateEqStatsMod();
        Character.Statistics.Hp.SetBaseValue(character.Statistics.MaxHp.Value);
        InitializeAbilities();
    }

    private void InitializeAbilities()
    {
        AbilitiesInUse = new List<Ability>();
        Abilities = new List<Ability>();
        AbilitiesExhausted = new List<Ability>();
        Abilities abilities = Character.Abilities;
        List<int> knownAbilities = abilities.KnownAbilities;
        foreach (var abilityId in knownAbilities)
        {
            Ability ability = abilities.GetAbility(abilityId);
            Abilities.Add(ability);
        }
    }

    public void DoTurn()
    {
        ExhaustedTime--;
        if (CheckReady() == true)
        {
            Attack();
            Debug.Log("AttackTurn");
        }
        else
        {
            //losu losu skila
            TryUseRandomAbility();
        }
        UpdateAbilitiesDuration();
        UpdateAbilitiesExhaust();
    }

    public void TryUseRandomAbility()
    {
        Ability randomAbility = GetRandomAbility();
        if (randomAbility != null)
        {
            Debug.Log("randomAbility");
            UseAbility(randomAbility);
        }
    }

    public void UseAbility(Ability ability)
    {
        ability.Execute(this, CacheOpponent);
        AbilitiesInUse.Add(ability);
        Abilities.Remove(ability);
    }

    public void UpdateAbilitiesDuration()
    {
        for (int i = AbilitiesInUse.Count - 1; i >= 0; i--)
        {
            if (AbilitiesInUse[i].CheckDurationTime())
            {
                AbilitiesInUse[i].RemoveEffects(this, CacheOpponent);
                AbilitiesExhausted.Add(AbilitiesInUse[i]);
                AbilitiesInUse.Remove(AbilitiesInUse[i]);
            }
        }
    }

    public void UpdateAbilitiesExhaust()
    {
        for (int i = AbilitiesExhausted.Count - 1; i >= 0; i--)
        {
            AbilitiesExhausted[i].ExhaustTime--;
            if (AbilitiesExhausted[i].ExhaustTime <= 0)
            {
                Abilities.Add(AbilitiesExhausted[i]);
                AbilitiesExhausted.Remove(AbilitiesExhausted[i]);
            }
        }
    }

    public Ability GetRandomAbility()
    {
        Ability randomAbility = null;

        if (Abilities.Count > 0)
        {
            randomAbility = Abilities[Random.Range(0, Abilities.Count)];
        }
        return randomAbility;
    }

    public bool CheckReady()
    {
        return ExhaustedTime <= 0;
    }

    public void Attack()
    {
        ExhaustedTime = Character.Statistics.AttackSpeed.Value * Random.Range(0.9f, 1.1f);
        CacheOpponent.Character.Statistics.Hp.AddValue(-Character.Statistics.Damage.Value * Random.Range(0.9f, 1.1f), false);
        OnCharacterAttacked();
        anim.Play("OneHandWeapon");
    }
}