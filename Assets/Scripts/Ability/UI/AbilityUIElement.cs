using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class AbilityUIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private TMPro.TMP_Text abilityName;
    [SerializeField]
    private Image abilityIcon;
    [SerializeField]
    private GameObject frame;
    [SerializeField]
    private AbilityWindowController controller;

    public bool IsChoose { get; set; }
    public Ability AbilityCache { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        List<int> list = Player.Instance.Character.Abilities.GetChoosedStyleAbilities(controller.CurrentStyle);

        if (IsChoose)
        {
            list.Remove(AbilityCache.AbilityInfo.Id);
        }
        else
        {
            list.Add(AbilityCache.AbilityInfo.Id);
        }

        Clicked();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void Init(Ability ability, bool isChoose)
    {
        AbilityCache = ability;
        abilityName.SetText(ability.AbilityInfo.Name);
        abilityIcon.sprite = ability.AbilityInfo.Icon;

        if (isChoose)
        {
            Clicked();
        }
    }

    private void Clicked()
    {
        IsChoose = !IsChoose;
        frame.SetActive(IsChoose);
    }
}
