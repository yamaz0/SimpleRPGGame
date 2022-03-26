using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilitiesUIWindowController : MonoBehaviour
{
    [SerializeField]
    private AbilityUI template;
    [SerializeField]
    private Transform content;

    public List<TrainerNPCInfo.AbilityId> AbilitiesIds { get; set; }
    public List<AbilityUI> AbilityUIs { get; set; } = new List<AbilityUI>();

    public void Init(TrainerNPCInfo npcInfo)
    {
        AbilitiesIds = npcInfo.AbilitiesIds;

        if (AbilityUIs.Count != 0)
        {
            for (int i = AbilityUIs.Count - 1; i >= 0; i--)
            {
                Destroy(AbilityUIs[i].gameObject);
            }
            AbilityUIs.Clear();
        }

        foreach (var abilityId in AbilitiesIds)
        {
            AbilityUI createdAbilityUI = Instantiate(template, content);
            createdAbilityUI.Init(abilityId);
            createdAbilityUI.gameObject.SetActive(true);
            AbilityUIs.Add(createdAbilityUI);
        }
    }
}
