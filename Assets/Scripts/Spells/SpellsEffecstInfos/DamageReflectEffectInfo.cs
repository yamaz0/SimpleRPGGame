using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "DamageReflectEffectInfo", menuName = "ScriptableObjects/Effects/DamageReflectEffectInfo")]
public class DamageReflectEffectInfo : SpellEffectInfo
{
    public float dmgPercentToReflect;

    public override SpellEffect GetSpellEffect()
    {
        return new DamageReflectEffect(this);
    }
}
