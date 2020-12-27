﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Effect]
[System.Serializable]
public class DamageMirrorEffect : SpellEffect
{
    private float dmgPercentToMirror;

    public override void Execute(Character<Attribute> character)
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveEffect(Character<Attribute> character)
    {
        throw new System.NotImplementedException();
    }

    public DamageMirrorEffect(DamageMirrorEffectInfo info)
        : base(info)
    {
        dmgPercentToMirror = info.dmgPercentToMirror;
    }
}
