using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attributes
{
    [SerializeField]
    private Modificator knowledge = new Modificator(1);
    [SerializeField]
    private Modificator concetration = new Modificator(1);
    [SerializeField]
    private Modificator will = new Modificator(1);
    [SerializeField]
    private Modificator mana = new Modificator(1);

    [ModificatorAttribute]
    public Modificator Knowledge { get => knowledge; set => knowledge = value; }
    [ModificatorAttribute]
    public Modificator Concetration { get => concetration; set => concetration = value; }
    [ModificatorAttribute]
    public Modificator Will { get => will; set => will = value; }
    [ModificatorAttribute]
    public Modificator Mana { get => mana; set => mana = value; }
}