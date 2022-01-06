using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField]
    private Attributes attributes = new Attributes();
    // [SerializeField]
    // private Dictionary<string, Modificator> dictModyficators = new Dictionary<string, Modificator>();
    [SerializeField]
    private InventoryController inventoryController;

    [SerializeField]
    private CharacterStatistics statistics = new CharacterStatistics();

    public Attributes Attributes { get => attributes; set => attributes = value; }
    public InventoryController InventoryController { get => inventoryController; set => inventoryController = value; }
    public CharacterStatistics Statistics { get => statistics; set => statistics = value; }

    // public Dictionary<string, Modificator> DictModyficators { get => dictModyficators; private set => dictModyficators = value; }

    // public Character()
    // {
    //     Initialize();
    // }

    public void Initialize()
    {
        InventoryController.Init();
    }

    // public List<Attribute> GetAttributes()
    // {
    //     return Attributes.AttributesList;
    // }

}