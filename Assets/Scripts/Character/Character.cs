﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField]
    private Attributes attributes = new Attributes();
    [SerializeField]
    private PlayerStatistics playerStatistics = new PlayerStatistics();
    [SerializeField]
    private List<int> knownSpellsId;
    // [SerializeField]
    // private Dictionary<string, Modificator> dictModyficators = new Dictionary<string, Modificator>();
    [SerializeField]
    private Inventory inventory;

    public Attributes Attributes { get => attributes; set => attributes = value; }
    public List<int> KnownSpellsId { get => knownSpellsId; set => knownSpellsId = value; }
    public Inventory Inventory { get => inventory; set => inventory = value; }
    public PlayerStatistics PlayerStatistics { get => playerStatistics; set => playerStatistics = value; }

    // public Dictionary<string, Modificator> DictModyficators { get => dictModyficators; private set => dictModyficators = value; }

    // public Character()
    // {
    //     Initialize();
    // }

    // public void Initialize()
    // {
    //     DictModyficators.Clear();
    //     foreach (ModificatorInfo info in ModificatorsSO.Instance.ModyficatorsInfo)
    //     {
    //         Modificator propertyInfo = ModificatorsSO.GetModifier(this, info);
    //         DictModyficators.Add(info.PropertyName, propertyInfo);
    //     }
    // }
    public void AddSpell(int id)
    {
        if (KnownSpellsId.Contains(id) == false)
        {
            KnownSpellsId.Add(id);
        }
    }

    // public List<Attribute> GetAttributes()
    // {
    //     return Attributes.AttributesList;
    // }

    public void CopyCharacter(Character characterCopy)
    {
        // for (int i = 0; i < Attributes.AttributesList.Count; i++)
        // {
        // Attributes.AttributesList[i].SetLevel(characterCopy.Attributes.AttributesList[i].Value);
        // }

        KnownSpellsId = new List<int>();
        KnownSpellsId.AddRange(characterCopy.KnownSpellsId);
    }
}