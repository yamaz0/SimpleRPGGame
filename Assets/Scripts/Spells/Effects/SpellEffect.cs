using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellEffect : MonoBehaviour
{
    private int duration;

    public abstract void Execute();

    public virtual bool CheckDuration()
    {
        duration--;

        if (duration <= 0)
        {
            return true;
        }

        return false;
    }

//zadawanie obrazen w czasie np podpalenie zatrucie itp
//zwiekszenie regenracji many na kilka tur
//odbicie czaru lub czesci dmg
//zwiekszenie odpornosci
//zwiekszenie obrazen
//

}
