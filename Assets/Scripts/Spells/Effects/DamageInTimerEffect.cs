using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageInTimerEffect : SpellEffect
{
    private float dmg;

    public override void Execute(Opponent opponent)
    {
        opponent.hp -= dmg;
    }

    public override void RemoveEffect(Opponent opponent)
    {
    }

    public DamageInTimerEffect(DamageInTimeEffectInfo info)
        : base(info)
    {
        dmg = info.dmg;
    }
}
