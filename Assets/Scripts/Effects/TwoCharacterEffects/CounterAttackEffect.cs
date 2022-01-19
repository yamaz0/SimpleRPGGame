using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CounterAttackEffect : TwoCharacterEffect
{
    [SerializeField]
    private float exhaustTime;
    public float CacheTime { get; set; }
    public Character CacheAtackerCharacter { get; set; }
    public Character CacheAtackedCharacter { get; set; }

    public override void Execute(Character atacker, Character atacked)
    {
        CacheAtackerCharacter = atacker;
        CacheAtackedCharacter = atacked;
        atacked.Statistics.Hp.OnValueChanged += TryReflectDamage;//DO POPRAWY BO NIE MOZE BYC EVENT HP TYLKO ON ATTACK EVENT CZY COS
    }

    public override void Remove(Character atacker, Character atacked)
    {
        atacked.Statistics.Hp.OnValueChanged -= TryReflectDamage;
    }

    public void TryReflectDamage(float damage)
    {
        if (CacheTime + exhaustTime < Time.fixedTime)
        {
            CacheTime = Time.fixedTime;
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
