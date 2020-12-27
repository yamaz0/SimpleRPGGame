using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "DamageMirrorEffectInfo", menuName = "ScriptableObjects/Effects/DamageMirrorEffectInfo")]
public class DamageMirrorEffectInfo : SpellEffectInfo
{
    public float dmgPercentToMirror;

    public override SpellEffect GetSpellEffect()
    {
        return new DamageMirrorEffect(this);
    }
}
