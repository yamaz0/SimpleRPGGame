using System;
using System.Collections;
using UnityEngine;
public interface IEffect
{
    void Execute(Character character);
}
public interface ITwoCharacterEffect
{
    void Execute(Character atacker, Character atacked);
}

[Serializable]
public class Effect
{
    [SerializeField]
    private string name;
    [SerializeField]
    private bool isSingleUse;

    public bool IsSingleUse { get => isSingleUse; set => isSingleUse = value; }
    public string Name { get => name; set => name = value; }
}