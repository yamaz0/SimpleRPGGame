using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShowArenaEffect : OneCharacterEffect
{
    public override void Execute(Character character)
    {
        WindowManager.Instance.ShowArena();
    }

    public override void Remove(Character character)
    {
        throw new NotImplementedException();
    }
}
