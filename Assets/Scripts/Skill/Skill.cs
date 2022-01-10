using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField]
    private string skillName;
    [SerializeReference]
    private List<OneCharacterEffect> efects;

    public List<OneCharacterEffect> Efects { get => efects; set => efects = value; }
    public string SkillName { get => skillName; set => skillName = value; }

    public void AddEffect(OneCharacterEffect e)
    {
        Efects.Add(e);
    }

    public void ExecuteEffects(Character character)
    {
        Efects.ForEach(x => x.Execute(character));
    }
}
