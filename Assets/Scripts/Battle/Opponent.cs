using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    private float exhaustedTime = 1;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private OpponentSpriteController spritesController;
    [SerializeField]
    private TMPro.TMP_Text hitText;
    [SerializeField]
    private BattleAbilitiesController battleAbilitiesController = new BattleAbilitiesController();

    public Character Character { get => character; set => character = value; }
    public float ExhaustedTime { get => exhaustedTime; set => exhaustedTime = value; }
    public Opponent CacheOpponent { get; set; }
    public Animator Anim { get => anim; set => anim = value; }
    public OpponentSpriteController SpritesController { get => spritesController; set => spritesController = value; }

    public event System.Action OnCharacterAttacked = delegate { };

    public void Initialize(Character character, Opponent opponent)
    {
        Character = character;
        CacheOpponent = opponent;
        SpritesController.SetSprites(Character);

        Character.Statistics.Hp.SetValue(character.Statistics.MaxHp.Value);
        battleAbilitiesController.InitializeAbilities(character);
    }


    public void DoTurn()
    {
        ExhaustedTime--;
        if (CheckReadyToAttack() == true)
        {
            Attack();
            // Debug.Log("AttackTurn");
        }
        else
        {
            //losu losu skila
            TryUseRandomAbility();
        }
        battleAbilitiesController.UpdateAbilities();
    }

    public void TryUseRandomAbility()
    {
        Ability randomAbility = battleAbilitiesController.GetRandomAbility();
        if (randomAbility != null)
        {
            // Debug.Log("randomAbility");
            randomAbility.Execute(this, CacheOpponent);
        }
    }


    public bool CheckReadyToAttack()
    {
        return ExhaustedTime <= 0;
    }

    public void Attack()
    {
        float attackSpeed = Character.Statistics.AttackSpeed.Value * Random.Range(0.9f, 1.1f);
        float critChance = Character.Statistics.CritChance.Value;
        float dodgeChance = CacheOpponent.Character.Statistics.DodgeChance.Value;
        float blockChance = CacheOpponent.Character.Statistics.BlockChance.Value;
        float bonusDamage = 0;

        ExhaustedTime = 60 / attackSpeed;

        OnCharacterAttacked();
        switch (Character.Style)
        {
            case FightStyle.OneHand:
                bonusDamage = Character.Statistics.OneHandedDamageBonus.Value;
                Anim.Play("OneHandWeapon");
                break;
            case FightStyle.TwoHand:
                bonusDamage = Character.Statistics.TwoHandedDamageBonus.Value;
                Anim.Play("TwoHandedAttack");
                break;
            case FightStyle.DualWield:
                bonusDamage = Character.Statistics.DualWieldDamageBonus.Value;
                Anim.Play("DualWielding");
                break;
            default:
                Anim.Play("OneHandWeapon");
                break;
        }

        if (Random.Range(0, 100) < dodgeChance)
        {
            //enemy Dodge
            CacheOpponent.SetHitText("DODGE");
            return;
        }

        if (Random.Range(0, 100) < blockChance)
        {
            //enemy block
            CacheOpponent.SetHitText("BLOCK");
            return;
        }
        float damage = Mathf.Max(1, Character.Statistics.Damage.Value * Random.Range(0.9f, 1.1f) - CacheOpponent.Character.Statistics.Defence.Value) + bonusDamage;

        if (Random.Range(0, 100) < critChance)
        {
            //character crit
            // SetHitText("CRIT");
            damage += damage;
        }

        CacheOpponent.DealDamage(damage);
    }

    public void DealDamage(float damage)
    {
        SetHitText(damage.ToString("N0"));
        Character.Statistics.Hp.AddValue(-damage, false);
    }

    private IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(0.5f);
        hitText.SetText(" ");
    }

    public void SetHitText(string text)
    {
        hitText.SetText(text);
        StartCoroutine(ResetHit());
    }
}