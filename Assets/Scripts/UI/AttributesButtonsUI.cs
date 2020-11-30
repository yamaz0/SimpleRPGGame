using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class AttributesButtonsUI
{
    [SerializeField]
    private Button but1;
    [SerializeField]
    private Button but2;

    public void Init()
    {
        but1.onClick.AddListener(() => Player.Instance.character.Attributes.AddAttributeLevel(AttributesScriptableObject.MagicAttributes.KNOWLEDGE));
        but2.onClick.AddListener(() => Player.Instance.character.Attributes.AddAttributeLevel(AttributesScriptableObject.MagicAttributes.CONCETRATION));
    }

    public void AddAtribute()
    {
        Player.Instance.character.Attributes.AddAttributeLevel(AttributesScriptableObject.MagicAttributes.KNOWLEDGE);
    }
}
