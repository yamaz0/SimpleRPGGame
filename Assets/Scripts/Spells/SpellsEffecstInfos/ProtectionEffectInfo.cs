using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "ProtectionEffectInfo", menuName = "ScriptableObjects/Effects/ProtectionEffectInfo")]
public class ProtectionEffectInfo : SpellEffectInfo
{
    public float dmgToAbsorb;

    public override SpellEffect GetSpellEffect()
    {
        return new DamageMirrorEffect1(this);
    }
}
