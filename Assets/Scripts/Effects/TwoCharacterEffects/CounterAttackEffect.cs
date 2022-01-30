using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CounterAttackEffect : TwoOponentBattleEffect
{
    [SerializeField]
    private float chanceCounterPercent;
    public Opponent CacheAtackerCharacter { get; set; }

    public override void Execute(Opponent atacker, Opponent atacked)
    {
        CacheAtackerCharacter = atacker;
        atacker.OnCharacterAttacked += TryCounter;
    }

    public override void Remove(Opponent atacker, Opponent atacked)
    {
        atacker.OnCharacterAttacked -= TryCounter;
    }

    public void TryCounter()
    {
        if (Random.Range(0, 1f) < chanceCounterPercent)
        {
            CacheAtackerCharacter.OnCharacterAttacked -= TryCounter;
            CacheAtackerCharacter.Attack();
        }
    }

#if UNITY_EDITOR
    public override void ViewFields()
    {
        base.ViewFields();
    }

    public override void ViewInfo()
    {
        base.ViewInfo();
    }
#endif
}
