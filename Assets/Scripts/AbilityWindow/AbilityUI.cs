using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private TMPro.TMP_Text priceText;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Button button;

    private Ability AbilityCache { get; set; }
    private int Cost { get; set; }

    public void Init(TrainerNPCInfo.AbilityId abilityId)
    {
        AbilityInfo abilityInfo = AbilityScriptableObject.Instance.GetAbilityInfoById(abilityId.ID);

        AbilityCache = new Ability(abilityInfo);
        Cost = abilityId.Cost;

        nameText.SetText(AbilityCache.AbilityInfo.Name);
        icon.sprite = AbilityCache.AbilityInfo.Icon;

        bool isPlayerKnowAbility = Player.Instance.Character.Abilities.KnownAbilities.Contains(abilityId.ID);

        if (isPlayerKnowAbility)
        {
            DeactiveAbilityUI();
        }
        else
        {
            priceText.SetText(Cost.ToString());
            button.onClick.AddListener(LearnAbility);
        }
    }

    private void DeactiveAbilityUI()
    {
        priceText.SetText("-----");
        button.gameObject.SetActive(false);
    }

    private void LearnAbility()
    {
        Character playerCharacter = Player.Instance.Character;
        playerCharacter.InventoryController.Inventory.AddGold(-Cost);
        playerCharacter.Abilities.AddAbility(AbilityCache.AbilityInfo.Id);
        DeactiveAbilityUI();
    }

}
