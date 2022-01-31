using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleStatistic
{
    float value;
    List<TwoOponentBattleEffect> effects;
    public float Calc()
    {
        return 0;
    }

}

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
        battleAbilitiesController.InitializeAbilities(character.Abilities);
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
        float v = Character.Statistics.AttackSpeed.Value * Random.Range(0.9f, 1.1f);
        ExhaustedTime = 60 / v;
        float damage = Mathf.Abs(Character.Statistics.Damage.Value * Random.Range(0.9f, 1.1f) - Character.Statistics.Defence.Value);

        CacheOpponent.Character.Statistics.Hp.AddValue(-damage, false);
        OnCharacterAttacked();
        switch (Character.Style)
        {
            case FightStyle.OneHand:
                Anim.Play("OneHandWeapon");
                break;
            case FightStyle.TwoHand:
                Anim.Play("TwoHandedAttack");
                break;
            case FightStyle.DualWield:
                Anim.Play("DualWielding");
                break;
            default:
                Anim.Play("OneHandWeapon");
                break;
        }
    }
}