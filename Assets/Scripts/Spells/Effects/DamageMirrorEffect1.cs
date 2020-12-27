using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Effect]
[System.Serializable]
public class DamageMirrorEffect1 : SpellEffect
{
    public override void Execute(Character<Attribute> character)
    {
    }

    public override void RemoveEffect(Character<Attribute> character)
    {
    }

    public DamageMirrorEffect1(SpellEffectInfo info)
        : base(info)
    {
        
    }
}
