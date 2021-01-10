using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "HealingEffectInfo", menuName = "ScriptableObjects/Effects/HealingEffectInfo")]
public class HealingEffectInfo : SpellEffectInfo
{
    public float healValue;

    public override SpellEffect GetSpellEffect()
    {
        return new HealingEffect(this);
    }
}
