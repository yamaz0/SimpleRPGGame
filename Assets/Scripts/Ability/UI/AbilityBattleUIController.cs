using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBattleUIController : MonoBehaviour
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private AbilityIcon template;
    [SerializeField]
    private List<AbilityIcon> abilityIcons = new List<AbilityIcon>();

    public void Init(List<Ability> abilities)
    {
        foreach (var ability in abilities)
        {
            AbilityIcon icon = Instantiate(template,content);
            icon.gameObject.SetActive(true);
            icon.Init(ability);
            abilityIcons.Add(icon);
        }
    }
}
