using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "DamageInTimeEffectInfo", menuName = "ScriptableObjects/Effects/DamageInTimeEffectInfo")]
public class DamageInTimeEffectInfo : SpellEffectInfo
{
    public float dmg;

    public override SpellEffect GetSpellEffect()
    {
        return new DamageInTimerEffect(this);
    }
}
