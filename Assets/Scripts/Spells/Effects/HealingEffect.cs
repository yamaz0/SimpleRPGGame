using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Effect]
[System.Serializable]
public class HealingEffect : SpellEffect
{
    private float healValue;

    public override void Execute(Opponent opponent)
    {
        opponent.hp += healValue;
    }

    public override void RemoveEffect(Opponent opponent)
    {
    }

    public HealingEffect(HealingEffectInfo info)
        : base(info)
    {
        healValue = info.healValue;
    }
}
