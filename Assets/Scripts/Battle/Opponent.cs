using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Opponent : MonoBehaviour
{
    private Character character;
    private float exhaustedTurn = 0;

    public Animator anim;
    public OpponentSpriteController spritesController;

    public Character Character { get => character; set => character = value; }
    public float Exhausted { get => exhaustedTurn; set => exhaustedTurn = value; }

    public void Initialize(Character character)
    {
        this.character = character;
        Item item1 = Character.InventoryController.GetItemByType(Equipement.EqType.HandLeft);

        if (item1 is WeaponItem wi)
        {
            Character.Statistics.Damage.AddValue(wi.Attack);
            Character.Statistics.AttackSpeed.AddValue(wi.AttackSpeed);
        }
        else if (item1 is ShieldItem si)
        {
            Character.Statistics.Defence.AddValue(si.Defense);
            Character.Statistics.BlockChance.AddValue(si.BlockChance);
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