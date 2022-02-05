using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomCharacter
{
    public static Character CreateRandomCharacterBalancedToCharacter(Character originalCharacter)
    {
        Character randomCharacter = new Character();

        RandomizeAttributes(originalCharacter, randomCharacter);

        randomCharacter.Style = (FightStyle)Random.Range(0, 3);

        PerksManager.Instance.TryAddAllAvaiblePerks(randomCharacter);

        SetRandomEquip(randomCharacter);

        SetRandomAbilities(randomCharacter);

        // string abilss = "abilities: ";
        // randomCharacter.Abilities.KnownAbilities.ForEach(x => abilss += x.ToString() + ", ");
        // Debug.Log(abilss);

        // string eqIds = "eq: ";
        // randomCharacter.InventoryController.Equipement.Items.ForEach(x => eqIds += x?.Id + ", ");
        // Debug.Log(eqIds);

        // Debug.Log("");
        // Debug.Log("LosuLosu");
        // Debug.Log("Strength: " + randomCharacter.Attributes.Strength.Value + " Dexterity: " + randomCharacter.Attributes.Dexterity.Value + " Endurance: " + randomCharacter.Attributes.Endurance.Value);


        return randomCharacter;
    }

    private static void SetRandomAbilities(Character randomCharacter)
    {
        List<BaseInfo> abilitiesInfo = AbilityScriptableObject.Instance.Objects.FindAll(x => ((AbilityInfo)x).Style == randomCharacter.Style || ((AbilityInfo)x).Style == FightStyle.None);

        for (int i = Random.Range(0, 5); i >= 0 && abilitiesInfo.Count > 0; i--)
        {
            BaseInfo randomAbilityInfo = abilitiesInfo[Random.Range(0, abilitiesInfo.Count)];
            randomCharacter.Abilities.AddAbility(randomAbilityInfo.Id);
            abilitiesInfo.Remove(randomAbilityInfo);
        }
    }

    private static void SetRandomEqElement(Character randomCharacter, List<ItemInfo> equipItems)
    {
        if (equipItems.Count == 0) return;

        EquipItemInfo randomEqItem = (EquipItemInfo)equipItems[Random.Range(0, equipItems.Count)];
        if (randomCharacter.InventoryController.Equipement.GetItemByType(randomEqItem.EquipmentType) == null)
        {
            randomCharacter.InventoryController.Equipement.EquipItem(randomEqItem.CreateItem(), randomEqItem.EquipmentType);
            equipItems.Remove(randomEqItem);
        }
    }

    private static void SetRandomEquip(Character randomCharacter)
    {
        randomCharacter.Initialize();

        List<ItemInfo> items = new List<ItemInfo>();

        foreach (ItemInfo item in ItemsScriptableObject.Instance.Objects)
        {
            if (item.ItemType == ItemsManager.ItemType.EQUIPMENT)
            {
                items.Add(item);
            }
        }

        switch (randomCharacter.Style)
        {
            case FightStyle.OneHand:
                SetRandomOneHandStyleItems(randomCharacter, items);
                break;
            case FightStyle.TwoHand:
                SetRandomTwoHandStyleItems(randomCharacter, items);
                break;
            case FightStyle.DualWield:
                SetRandomDualWieldStyleItems(randomCharacter, items);
                break;
            default:
                Debug.LogError("Cant create random character! Style not exist.");
                break;
        }

        List<ItemInfo> equipItems = items.FindAll(x => x is EquipItemInfo);
        for (int i = 0; i < 12; i++)//2x more chance to full equip
        {
            SetRandomEqElement(randomCharacter, equipItems);
        }
    }

    private static void SetRandomDualWieldStyleItems(Character randomCharacter, List<ItemInfo> items)
    {
        List<ItemInfo> weaponsitems = items.FindAll(x => x is WeaponItemInfo w && !w.TwoHanded);

        Item leftWeapon = weaponsitems[Random.Range(0, weaponsitems.Count)].CreateItem();
        Item righWeapon = weaponsitems[Random.Range(0, weaponsitems.Count)].CreateItem();

        randomCharacter.InventoryController.Equipement.EquipItem(leftWeapon, Equipement.EqType.HandLeft);
        randomCharacter.InventoryController.Equipement.EquipItem(righWeapon, Equipement.EqType.HandRight);
    }

    private static void SetRandomTwoHandStyleItems(Character randomCharacter, List<ItemInfo> items)
    {
        List<ItemInfo> weaponsitems = items.FindAll(x => x is WeaponItemInfo w && w.TwoHanded);

        Item twohandedWeapon = weaponsitems[Random.Range(0, weaponsitems.Count)].CreateItem();

        randomCharacter.InventoryController.Equipement.EquipItem(twohandedWeapon, Equipement.EqType.HandLeft);
    }

    private static void SetRandomOneHandStyleItems(Character randomCharacter, List<ItemInfo> items)
    {
        List<ItemInfo> weaponsitems = items.FindAll(x => x is WeaponItemInfo w && !w.TwoHanded);
        List<ItemInfo> shielditems = items.FindAll(x => x is ShieldItemInfo s);

        Item weapon = weaponsitems[Random.Range(0, weaponsitems.Count)].CreateItem();
        Item shield = shielditems[Random.Range(0, shielditems.Count)].CreateItem();

        randomCharacter.InventoryController.Equipement.EquipItem(weapon, Equipement.EqType.HandLeft);
        randomCharacter.InventoryController.Equipement.EquipItem(shield, Equipement.EqType.HandRight);
    }

    private static void RandomizeAttributes(Character originalCharacter, Character randomCharacter)
    {
        Attributes originalAttributes = originalCharacter.Attributes;
        int attributesPoints = (int)(originalAttributes.Dexterity.Value + originalAttributes.Strength.Value + originalAttributes.Endurance.Value);
        // int attributesPoints = 100;

        int attributesPointsOffsetTenPercent = (int)(attributesPoints * 0.1f);
        int minRadnom = attributesPoints - attributesPointsOffsetTenPercent;
        int maxRadnom = attributesPoints + attributesPointsOffsetTenPercent;
        int attributesPointsToSpend = Random.Range(minRadnom, maxRadnom);

        SetAttributeRandomValue(randomCharacter.Attributes.Strength, ref attributesPointsToSpend);
        SetAttributeRandomValue(randomCharacter.Attributes.Dexterity, ref attributesPointsToSpend);
        randomCharacter.Attributes.Endurance.SetBaseValue(Mathf.Max(1, attributesPointsToSpend));
    }

    private static void SetAttributeRandomValue(Modificator mod, ref int attributesPointsToSpend)
    {
        int randomValue = Random.Range(1, attributesPointsToSpend);
        mod.SetBaseValue(randomValue);
        attributesPointsToSpend -= randomValue;
    }
}
