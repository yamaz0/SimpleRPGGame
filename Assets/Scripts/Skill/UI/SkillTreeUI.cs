using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text text;
    [SerializeField]
    private Button btn;

    [SerializeField]
    private SkillScriptableObject skill;


private void Start() {
    text.SetText(skill.Skill.SkillName);
    btn.onClick.AddListener(click);
}

    public void click()
    {
        skill.Skill.ExecuteEffects(Player.Instance.Character);
    }
}
