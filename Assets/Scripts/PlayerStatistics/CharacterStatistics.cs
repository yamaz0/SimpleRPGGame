using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ModificatorType]
public class CharacterStatistics
{
    [SerializeField]
    private Modificator hp = new Modificator(100);
    [SerializeField]
    private Modificator damage = new Modificator(1);
    [SerializeField]
    private Modificator attackSpeed = new Modificator(1);
    [SerializeField]
    private Modificator defence = new Modificator(0);
    [SerializeField]
    private Modificator dodgeChance = new Modificator(0);
    [SerializeField]
    private Modificator blockChance = new Modificator(0);
    [SerializeField]
    private Modificator critChance = new Modificator(0);

    [Modificator]
    public Modificator Hp { get => hp; set => hp = value; }
    [Modificator]
    public Modificator Damage { get => damage; set => damage = value; }
    [Modificator]
    public Modificator Defence { get => defence; set => defence = value; }
    [Modificator]
    public Modificator DodgeChance { get => dodgeChance; set => dodgeChance = value; }
    [Modificator]
    public Modificator BlockChance { get => blockChance; set => blockChance = value; }
    [Modificator]
    public Modificator CritChance { get => critChance; set => critChance = value; }
    public Modificator AttackSpeed { get => attackSpeed; set => attackSpeed = value; }

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
