using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Effect]
[System.Serializable]
public class DamageReflectEffect : SpellEffect
{
    private float dmgPercentToReflect;

    public override void Execute(Opponent opponent)
    {
        // opponent.ReflectNextAttack = true;
        // opponent.ReflectionPercent = dmgPercentToReflect;
    }

    public override void RemoveEffect(Opponent opponent)
    {
        throw new System.NotImplementedException();
    }

    public DamageReflectEffect(DamageReflectEffectInfo info)
        : base(info)
    {
        dmgPercentToReflect = info.dmgPercentToReflect;
    }
}
