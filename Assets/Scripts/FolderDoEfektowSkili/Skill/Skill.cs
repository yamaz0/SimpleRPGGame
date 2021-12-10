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
    private List<Effect> efects;

    public List<Effect> Efects { get => efects; set => efects = value; }
    public string SkillName { get => skillName; set => skillName = value; }

    public void AddEffect(Effect e)
    {
        Efects.Add(e);
    }

    public void ExecuteEffects(Character character)
    {
        Efects.ForEach(x => x.Execute(character));
    }
}
