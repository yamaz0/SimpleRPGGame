﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Effect]
[System.Serializable]
public class DamageMirrorEffect1 : SpellEffect
{
    public override void Execute(Opponent opponent)
    {
    }

    public override void RemoveEffect(Opponent opponent)
    {
    }

    public DamageMirrorEffect1(SpellEffectInfo info)
        : base(info)
    {
        
    }
}
