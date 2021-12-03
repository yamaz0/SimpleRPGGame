using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    void Execute(Character reveiver, Character target);
}

[System.Serializable]
public class Effect
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }

    // public void Execute(Character reveiver, Character target)
    // {
    //     throw new System.NotImplementedException();
    // }
}

public class AddEffect: Effect
{

}