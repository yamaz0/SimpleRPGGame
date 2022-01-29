using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FightStyle { OneHand, TwoHand, DualWield }

[System.Serializable]
public class Character
{
    [SerializeField]
    private Attributes attributes = new Attributes();
    [SerializeField]
    private InventoryController inventoryController = new InventoryController();
    [SerializeField]
    private Abilities abilities = new Abilities();
    [SerializeField]
    private Perks perks = new Perks();
    [SerializeField]
    private CharacterStatistics statistics = new CharacterStatistics();
    [SerializeField]
    private FightStyle style;

    public Attributes Attributes { get => attributes; set => attributes = value; }
    public InventoryController InventoryController { get => inventoryController; set => inventoryController = value; }
    public CharacterStatistics Statistics { get => statistics; set => statistics = value; }
    public Abilities Abilities { get => abilities; set => abilities = value; }
    public Perks Perks { get => perks; set => perks = value; }
    public FightStyle Style { get => style; set => style = value; }

    public void Initialize()
    {
        InventoryController.Init();
        InventoryController.Equipement.OnEquipmentChanged += UpdateEqStatsMod;
    }

    public void UpdateEqStatsMod()
    {
        List<Item> items = InventoryController.Equipement.Items;

        float atk = 0;
        float def = 0;
        float atcSpeed = 0;
        float blockChance = 0;

        foreach (Item item in items)
        {
            if (item is EquipItem ei)
            {
                def += ei.Defense;
            }
            else if (item is WeaponItem wi)
            {
                atk += wi.Attack;
                atcSpeed += wi.AttackSpeed;
            }
            else if (item is ShieldItem si)
            {
                blockChance += si.BlockChance;
                def += si.Defense;
            }
        }
        Statistics.Defence.SetValue(def);
        Statistics.Damage.SetValue(atk);
        Statistics.AttackSpeed.SetValue(atcSpeed);
        Statistics.BlockChance.SetValue(blockChance);
    }

}