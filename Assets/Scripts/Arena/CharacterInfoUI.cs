using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterInfoUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text characterNameText;
    [SerializeField]
    private TextValueUI strenght;
    [SerializeField]
    private TextValueUI dexterity;
    [SerializeField]
    private TextValueUI endurance;
    [SerializeField]
    private Slot leftHand;
    [SerializeField]
    private Slot rightHand;
    [SerializeField]
    private Button button;

    protected OneCharacterEffect Effect { get; set; }
    public Character CacheCharacter { get; set; }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    public virtual void Init(Character character)
    {
        CacheCharacter = character;

        characterNameText.SetText(CacheCharacter.Name);
        strenght.Init("Strength", CacheCharacter.Attributes.Strength.Value.ToString());
        dexterity.Init("Dexterity", CacheCharacter.Attributes.Dexterity.Value.ToString());
        endurance.Init("Endurance", CacheCharacter.Attributes.Endurance.Value.ToString());

        Item left = CacheCharacter.InventoryController.GetItemByType(Equipement.EqType.HandLeft);
        Item right = CacheCharacter.InventoryController.GetItemByType(Equipement.EqType.HandRight);

        SetSlot(leftHand, left);
        SetSlot(rightHand, right);

        Effect = new StartDuelBattleEffect();
    }

    protected void SetSlot(Slot slot, Item item)
    {

        if (item != null)
        {
            slot.gameObject.SetActive(true);
            slot.Init(item, null);
        }
        else
        {
            slot.ItemCache = null;
            slot.gameObject.SetActive(false);
        }
    }

    public void OnButtonClicked()
    {
        Effect.Execute(CacheCharacter);
    }
}
