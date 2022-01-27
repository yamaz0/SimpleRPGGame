using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Perk
{
    [SerializeField]
    private string perkName;
    [SerializeReference]
    private List<OneCharacterEffect> efects;

    public List<OneCharacterEffect> Efects { get => efects; set => efects = value; }
    public string PerkName { get => perkName; set => perkName = value; }

    public void AddEffect(OneCharacterEffect e)
    {
        Efects.Add(e);
    }

    public void ExecuteEffects(Character character)
    {
        Efects.ForEach(x => x.Execute(character));
    }
}
