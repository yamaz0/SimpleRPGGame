using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ModificatorType]
public class PlayerStatistics
{
    [SerializeField]
    private Modificator dodgeChance = new Modificator(0);
    [SerializeField]
    private Modificator blockChance = new Modificator(0);
    [SerializeField]
    private Modificator critChance = new Modificator(0);

    [Modificator]
    public Modificator DodgeChance { get => dodgeChance; set => dodgeChance = value; }
    [Modificator]
    public Modificator BlockChance { get => blockChance; set => blockChance = value; }
    [Modificator]
    public Modificator CritChance { get => critChance; set => critChance = value; }

    public Modificator GetStatistic(string attributeName)
    {
        switch (attributeName)
        {
            case "DodgeChance": return DodgeChance;
            case "BlockChance": return BlockChance;
            case "CritChance": return CritChance;
            default:
                Debug.LogError("PlayerStatistics name not exist!");
                return null;
        }
    }
}
