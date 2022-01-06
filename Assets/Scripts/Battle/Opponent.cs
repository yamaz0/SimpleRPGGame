using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    public float hp = 10;
    private float exhaustedTurn = 0;

    private float damage=1;
    private float attackspeed = 1;
    private float defence;
    private float blockChange;


    public Animator anim;
    public OpponentSpriteController spritesController;

    public Character Character { get => character; set => character = value; }
    public float Exhausted { get => exhaustedTurn; set => exhaustedTurn = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Defence { get => defence; set => defence = value; }
    public float Attackspeed { get => attackspeed; set => attackspeed = value; }
    public float BlockChange { get => blockChange; set => blockChange = value; }

    public void Initialize(Character character)
    {
        this.character = character;
        Item item1 = Character.InventoryController.GetItemByType(Equipement.EqType.HandLeft);

        if (item1 is WeaponItem wi)
        {
            Damage += wi.Attack;
            Attackspeed += wi.AttackSpeed;
        }
        else if (item1 is ShieldItem si)
        {
            Defence += si.Defense;
            BlockChange += si.BlockChance;
        }
    }

    public bool CheckReady()
    {
        return Exhausted <= 0;
    }

    public void Attack()
    {
        anim.Play("Attack");
    }
}