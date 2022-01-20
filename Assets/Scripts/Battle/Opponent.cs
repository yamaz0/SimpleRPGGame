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

    public enum FightStyle { OneHandWeapon, TwoHandWeapon, DualWield }

    public void Initialize(Character character)
    {
        Character = character;
        SetSprites();
        Character.UpdateEqStatsMod();
        Character.Statistics.Hp.SetBaseValue(character.Statistics.MaxHp.Value);
    }

    private void SetSprites()
    {
        foreach (Equipement.EqType t in (Equipement.EqType[])System.Enum.GetValues(typeof(Equipement.EqType)))
        {
            Item item = Character.InventoryController.GetItemByType(t);
            if (item != null)
                spritesController.SetItemSprite(t, item.Icon);
        }
    }

    public bool CheckReady()
    {
        return Exhausted <= 0;
    }

    public void Attack()
    {
        anim.Play("OneHandWeapon");
    }
}