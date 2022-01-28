using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ModificatorType]
public class CharacterStatistics
{
    [SerializeField]
    private Modificator maxHp = new Modificator(100);
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
    [SerializeField]
    private Modificator hp = new Modificator(0);
    [SerializeField]
    private Modificator exp = new Modificator(0);
    [SerializeField]
    private Modificator twoHandedDamageBonus = new Modificator(0);
    [SerializeField]
    private Modificator oneHandedDamageBonus = new Modificator(0);
    [SerializeField]
    private Modificator dualWieldDamageBonus = new Modificator(0);



    [Modificator]
    public Modificator Damage { get => damage; set => damage = value; }//bazowe obrazenia plus dodatkowe tymczasowe z ekwipunku lub efektow podczas walki
    [Modificator]
    public Modificator Defence { get => defence; set => defence = value; }//bazowa obrona plus dodatkowe tymczasowe z ekwipunku lub efektow podczas walki
    [Modificator]
    public Modificator DodgeChance { get => dodgeChance; set => dodgeChance = value; }
    [Modificator]
    public Modificator BlockChance { get => blockChance; set => blockChance = value; }
    [Modificator]
    public Modificator CritChance { get => critChance; set => critChance = value; }
    [Modificator]
    public Modificator AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    [Modificator]
    public Modificator MaxHp { get => maxHp; set => maxHp = value; }
    [Modificator]
    public Modificator Exp { get => exp; set => exp = value; }
    [Modificator]
    public Modificator TwoHandedDamageBonus { get => twoHandedDamageBonus; set => twoHandedDamageBonus = value; }
    [Modificator]
    public Modificator OneHandedDamageBonus { get => oneHandedDamageBonus; set => oneHandedDamageBonus = value; }
    [Modificator]
    public Modificator DualWieldDamageBonus { get => dualWieldDamageBonus; set => dualWieldDamageBonus = value; }

    public Modificator Hp { get => hp; set => hp = value; }

    public Modificator GetStatistic(string attributeName)
    {
        switch (attributeName)
        {
            case "Hp": return Hp;
            case "Damage": return Damage;
            case "Defence": return Defence;
            case "DodgeChance": return DodgeChance;
            case "BlockChance": return BlockChance;
            case "CritChance": return CritChance;
            case "AttackSpeed": return AttackSpeed;
            case "MaxHp": return MaxHp;
            case "Exp": return Exp;
            default:
                Debug.LogError($"Character statistic: {attributeName} name not exist!");
                return null;
        }
    }
}
