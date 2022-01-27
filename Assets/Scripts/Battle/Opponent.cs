using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    private float exhaustedTime = 1;
    [SerializeField]
    private AbilityBattleUIController abilityBattleUIController;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private OpponentSpriteController spritesController;

    public Character Character { get => character; set => character = value; }
    public float ExhaustedTime { get => exhaustedTime; set => exhaustedTime = value; }
    public List<Ability> Abilities { get; set; }
    public List<Ability> AbilitiesLosuLosu { get; set; }
    public Opponent CacheOpponent { get; set; }
    public Animator Anim { get => anim; set => anim = value; }
    public OpponentSpriteController SpritesController { get => spritesController; set => spritesController = value; }

    public event System.Action OnCharacterAttacked = delegate { };

    public enum FightStyle { OneHandWeapon, TwoHandWeapon, DualWield }

    public void Initialize(Character character, Opponent opponent)
    {
        Character = character;
        CacheOpponent = opponent;
        SpritesController.SetSprites(Character);
        Character.UpdateEqStatsMod();
        Character.Statistics.Hp.SetValue(character.Statistics.MaxHp.Value);
        Character.Statistics.Hp.SetBaseValue(0);
        InitializeAbilities();
        abilityBattleUIController.Init(Abilities);
    }

    private void InitializeAbilities()
    {
        Abilities = new List<Ability>();
        AbilitiesLosuLosu = new List<Ability>();
        Abilities abilities = Character.Abilities;
        List<int> knownAbilities = abilities.KnownAbilities;
        foreach (var abilityId in knownAbilities)
        {
            Ability ability = abilities.GetAbility(abilityId);
            ability.OnStateChanged += changedState => UpdateAbility(ability, changedState);
            Abilities.Add(ability);
            AbilitiesLosuLosu.Add(ability);
        }
    }

    public void DoTurn()
    {
        ExhaustedTime--;
        if (CheckReadyToAttack() == true)
        {
            Attack();
            Debug.Log("AttackTurn");
        }
        else
        {
            //losu losu skila
            TryUseRandomAbility();
        }
        UpdateAbilities();
    }

    public void TryUseRandomAbility()
    {
        Ability randomAbility = GetRandomAbility();
        if (randomAbility != null)
        {
            Debug.Log("randomAbility");
            randomAbility.Execute(this, CacheOpponent);
        }
    }

    public void UpdateAbility(Ability ability, AbilityState abilityState)
    {
        switch (abilityState)
        {
            case AbilityState.Ready:
                AbilitiesLosuLosu.Add(ability);
                break;
            case AbilityState.InUse:
                AbilitiesLosuLosu.Remove(ability);
                break;
            case AbilityState.Exhaust:
                ability.RemoveEffects(this, CacheOpponent);
                break;
            default:
                Debug.LogError("AbilityState not exist!");
                break;
        }
    }

    public void UpdateAbilities()
    {
        for (int i = Abilities.Count - 1; i >= 0; i--)
        {
            Abilities[i].UpdateTime();
        }
    }

    public Ability GetRandomAbility()
    {
        Ability randomAbility = null;

        if (AbilitiesLosuLosu.Count > 0)
        {
            randomAbility = AbilitiesLosuLosu[Random.Range(0, AbilitiesLosuLosu.Count)];
        }
        return randomAbility;
    }

    public bool CheckReadyToAttack()
    {
        return ExhaustedTime <= 0;
    }

    public void Attack()
    {
        ExhaustedTime = Character.Statistics.AttackSpeed.Value * Random.Range(0.9f, 1.1f);
        CacheOpponent.Character.Statistics.Hp.AddValue(-Character.Statistics.Damage.Value * Random.Range(0.9f, 1.1f), false);
        OnCharacterAttacked();
        Anim.Play("OneHandWeapon");
    }
}