using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AbilityWindowController : MonoBehaviour
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private AbilityUIElement template;
    [SerializeField]
    private List<AbilityUIElement> abilitiesObjects = new List<AbilityUIElement>();
    [SerializeField]
    private Button oneHandStyleButton;
    [SerializeField]
    private Button twoHandStyleButton;
    [SerializeField]
    private Button dualWieldStyleButton;

    public FightStyle CurrentStyle { get; set; }

    private void Start()
    {
        oneHandStyleButton.onClick.AddListener(() => { FillContentWithStyle(FightStyle.OneHand); });
        twoHandStyleButton.onClick.AddListener(() => { FillContentWithStyle(FightStyle.TwoHand); });
        dualWieldStyleButton.onClick.AddListener(() => { FillContentWithStyle(FightStyle.DualWield); });
    }

    private void OnEnable()
    {
        FillContentWithStyle(Player.Instance.Character.Style);
        //todo dorobic limit na ilosc skili wybranych i zaznaczanie i odznaczanie ich no i tooltipy by sie przydaly hehe
    }

    public void FillContentWithStyle(FightStyle style)
    {
        Abilities abilities = Player.Instance.Character.Abilities;
        List<int> list = abilities.GetChoosedStyleAbilities(style);
        CurrentStyle = style;

        for (int i = abilitiesObjects.Count - 1; i >= 0; i--)
        {
            Destroy(abilitiesObjects[i].gameObject);
        }

        abilitiesObjects.Clear();

        foreach (var abilityId in abilities.KnownAbilities)
        {
            Ability ability = abilities.GetAbility(abilityId);

            if (ability.AbilityInfo.Style == style || ability.AbilityInfo.Style == FightStyle.None)
            {
                bool isChoosed = list.Contains(abilityId);
                AbilityUIElement abilityUIElement = Instantiate(template, content);

                abilityUIElement.Init(ability, isChoosed);
                abilityUIElement.gameObject.SetActive(true);
                abilitiesObjects.Add(abilityUIElement);
            }
        }

    }
}
