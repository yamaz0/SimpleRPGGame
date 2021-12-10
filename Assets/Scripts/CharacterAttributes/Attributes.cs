using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ModificatorType]
public class Attributes
{
    [SerializeField]
    private Modificator strength = new Modificator(1);
    [SerializeField]
    private Modificator dexterity = new Modificator(1);
    [SerializeField]
    private Modificator endurance = new Modificator(1);

    [Modificator]
    public Modificator Strength { get => strength; set => strength = value; }
    [Modificator]
    public Modificator Dexterity { get => dexterity; set => dexterity = value; }
    [Modificator]
    public Modificator Endurance { get => endurance; set => endurance = value; }

    public Modificator GetAttribute(string attributeName)
    {
        switch (attributeName)
        {
            case "Strength": return Strength;
            case "Dexterity": return Dexterity;
            case "Endurance": return Endurance;
            default:
                Debug.LogError("Attribute name not exist!");
                return null;
        }
    }
}