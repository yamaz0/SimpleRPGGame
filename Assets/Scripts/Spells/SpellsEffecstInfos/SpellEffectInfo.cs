using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SpellEffectInfo : ScriptableObject
{
    [SerializeField]
    private string effectName;
    [SerializeField]
    private int id;
    [SerializeField]
    private int duration;
    [SerializeField]
    bool isRepeatable = false;
    [SerializeField]
    bool isSingleUse = false;

    public string EffectName { get => effectName; private set => effectName = value; }
    public int Id { get => id; private set => id = value; }
    public int Duration { get => duration; set => duration = value; }
    public bool IsRepeatable { get => isRepeatable; set => isRepeatable = value; }
    public bool IsSingleUse { get => isSingleUse; set => isSingleUse = value; }

    public abstract SpellEffect GetSpellEffect();
}