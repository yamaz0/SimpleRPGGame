using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FightStyle { OneHand, TwoHand, DualWield, None }

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
        InventoryController.Equipement.OnEquipmentChanged += UpdateStatsMod;
        // Attributes.Strength.OnValueChanged += UpdateStatsMod;
        // Attributes.Dexterity.OnValueChanged += UpdateStatsMod;
        // Attributes.Endurance.OnValueChanged += UpdateStatsMod;
        UpdateStatsMod();
    }

    public void OnDisable()
    {
        InventoryController.Equipement.OnEquipmentChanged -= UpdateStatsMod;
    }

    public void UpdateStatsMod()
    {
        List<Item> items = InventoryController.Equipement.Items;

        float atk = 0;
        float critChance = Attributes.Strength.Value;
        float def = 0;
        float atcSpeed = 0;
        float blockChance = 0;
        float dodge = Attributes.Dexterity.Value;
        float maxHp = Attributes.Endurance.Value * 5;

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
                blockChance = si.BlockChance;
                def += si.Defense;
            }
        }


        atk += Attributes.Strength.Value * 2;
        atcSpeed += Attributes.Dexterity.Value * 0.5f;

        Statistics.Defence.SetValue(def);
        Statistics.CritChance.SetValue(critChance);
        Statistics.Damage.SetValue(atk);
        Statistics.AttackSpeed.SetValue(atcSpeed);
        Statistics.BlockChance.SetValue(blockChance);
        Statistics.DodgeChance.SetValue(dodge);
        Statistics.MaxHp.SetValue(maxHp);
    }

}