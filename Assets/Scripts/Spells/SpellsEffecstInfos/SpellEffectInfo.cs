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

    public string EffectName { get => effectName; private set => effectName = value; }
    public int Id { get => id; private set => id = value; }
    public int Duration { get => duration; set => duration = value; }

    public abstract SpellEffect GetSpellEffect();
}