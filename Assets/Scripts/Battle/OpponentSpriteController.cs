using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSpriteController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer attack;
    [SerializeField]
    private SpriteRenderer defend;
    [SerializeField]
    private SpriteRenderer spellEffect;
    [SerializeField]
    private SpriteRenderer targetEffect;

    public void SetAttackSprite(Sprite sprite)
    {
        attack.sprite = sprite;
    }
    public void SetDefendSprite(Sprite sprite)
    {
        defend.sprite = sprite;
    }
    public void SetSpellEffectSprite(Sprite sprite)
    {
        spellEffect.sprite = sprite;
    }
    public void SetTargetEffectSprite(Sprite sprite)
    {
        targetEffect.sprite = sprite;
    }

}
