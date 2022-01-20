using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField]
    private Attributes attributes = new Attributes();
    [SerializeField]
    private InventoryController inventoryController;
    [SerializeField]
    private Abilities abilities;
    [SerializeField]
    private CharacterStatistics statistics = new CharacterStatistics();

    public Attributes Attributes { get => attributes; set => attributes = value; }
    public InventoryController InventoryController { get => inventoryController; set => inventoryController = value; }
    public CharacterStatistics Statistics { get => statistics; set => statistics = value; }
    public Abilities Abilities { get => abilities; set => abilities = value; }

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