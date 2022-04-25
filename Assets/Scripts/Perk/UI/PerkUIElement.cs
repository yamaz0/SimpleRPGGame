using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PerkUIElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TMPro.TMP_Text perkName;
    [SerializeField]
    private Image perkIcon;

    public Perk PerkCache { get; set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PopUpManager.Instance.ShowPerkTooltip(PerkCache, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PopUpManager.Instance.PerkTooltip.gameObject.SetActive(false);
    }

    public void Init(Perk perk)
    {
        PerkCache = perk;
        perkName.SetText(perk.PerkInfo.Name);
        perkIcon.sprite = perk.PerkInfo.Icon;
    }
}