using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SpellEffect
{
    [SerializeField]
    private int id;
    [SerializeField]
    private int duration;
    [SerializeField]
    bool isRepeatable = false;
    [SerializeField]
    bool isSingleUse = false;

    public bool IsRepeatable { get => isRepeatable; set => isRepeatable = value; }
    public bool IsSingleUse { get => isSingleUse; set => isSingleUse = value; }

    public abstract void Execute(Opponent opponent);
    public abstract void RemoveEffect(Opponent opponent);

    public bool CheckDurationEffect()
    {
        duration--;

        if (duration <= 0)
        {
            return false;
        }

        return true;
    }

    public SpellEffect(SpellEffectInfo info)
    {
        id = info.Id;
        duration = info.Duration;
        IsRepeatable=info.IsRepeatable;
        IsSingleUse=info.IsSingleUse;
        //TODO boole i inne jesli bedo
    }

    //zadawanie obrazen w czasie np podpalenie zatrucie itp
    //zwiekszenie regenracji many na kilka tur
    //odbicie czaru lub czesci dmg
    //zwiekszenie odpornosci
    //zwiekszenie obrazen
    //

}

[AttributeUsage(AttributeTargets.Class)]
public class Effect : System.Attribute
{

}
