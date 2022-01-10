using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class AttackEffect : TwoCharacterEffect
{
    [SerializeField]
    private List<OperatorEffect> operators = new List<OperatorEffect>();
    [SerializeField]
    private int atak;

    public List<OperatorEffect> Operators { get => operators; set => operators = value; }
    public float CacheValue { get; set; }
    public int Atak { get => atak; set => atak = value; }

    public AttackEffect()
    {
        IsSingleUse = true;
    }

    public override void Execute(Character atacker, Character atacked)
    {
        foreach (var op in Operators)
        {
            CacheValue += op.Calc(atacker);
        }

        atacked.Statistics.Hp.AddValue(-CacheValue);
    }

    public override void Remove(Character atacker, Character atacked)
    {
        // atacked.Statistics.Hp.AddValue(CacheValue);
        Debug.LogError("Attack ");
    }
}