using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PerkWindowController : MonoBehaviour
{
    [SerializeField]
    private PerkUIElement template;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private List<PerkUIElement> perksUIElements = new List<PerkUIElement>();

    private void OnEnable()
    {
        List<Perk> perks = Player.Instance.Character.Perks.GetPerks();

        for (int i = perksUIElements.Count - 1; i >= 0; i--)
        {
            Destroy(perksUIElements[i].gameObject);
        }

        perksUIElements.Clear();

        foreach (var perk in perks)
        {
            PerkUIElement perkUIElement = Instantiate(template, content);

            perkUIElement.Init(perk);
            perkUIElement.gameObject.SetActive(true);
            perksUIElements.Add(perkUIElement);
        }
    }

}
