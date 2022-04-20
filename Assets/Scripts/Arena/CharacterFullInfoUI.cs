using UnityEngine;

public class CharacterFullInfoUI : CharacterInfoUI
{

    [SerializeField]
    private Slot helmetSlot;
    [SerializeField]
    private Slot armorSlot;
    [SerializeField]
    private Slot legsSlot;
    [SerializeField]
    private Slot bootsSlot;

    public Slot HelmetSlot { get => helmetSlot; set => helmetSlot = value; }
    public Slot ArmorSlot { get => armorSlot; set => armorSlot = value; }
    public Slot LegsSlot { get => legsSlot; set => legsSlot = value; }
    public Slot BootsSlot { get => bootsSlot; set => bootsSlot = value; }

    public override void Init(Character character)
    {
        base.Init(character);

        Effect = new StartTournamentBattleEffect();

        Item helmet = CacheCharacter.InventoryController.GetItemByType(Equipement.EqType.Helmet);
        Item armor = CacheCharacter.InventoryController.GetItemByType(Equipement.EqType.Armor);
        Item legs = CacheCharacter.InventoryController.GetItemByType(Equipement.EqType.Legs);
        Item boots = CacheCharacter.InventoryController.GetItemByType(Equipement.EqType.Boots);

        SetSlot(HelmetSlot, helmet);
        SetSlot(ArmorSlot, armor);
        SetSlot(LegsSlot, legs);
        SetSlot(BootsSlot, boots);
    }
}
