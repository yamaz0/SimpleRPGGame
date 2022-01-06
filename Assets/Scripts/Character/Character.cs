using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField]
    private Attributes attributes = new Attributes();
    [SerializeField]
    private PlayerStatistics playerStatistics = new PlayerStatistics();
    // [SerializeField]
    // private Dictionary<string, Modificator> dictModyficators = new Dictionary<string, Modificator>();
    [SerializeField]
    private InventoryController inventoryController;
    // private Inventory inventory;

    public Attributes Attributes { get => attributes; set => attributes = value; }
    public InventoryController InventoryController { get => inventoryController; set => inventoryController = value; }
    public PlayerStatistics PlayerStatistics { get => playerStatistics; set => playerStatistics = value; }

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